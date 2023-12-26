using Aibote4Sharp.scripts;
using Aibote4Sharp.sdk;
using System.Data;
using System.Diagnostics;

namespace Aibote4Sharp
{
    public partial class Form1 : Form
    {

        Thread? t1;
        Thread? t2;
        Thread? t3;
        private DataTable aibotes = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        // 初始化DataGridView控件  
        private void InitializeDataGridView()
        {
            // 添加列到数据源  
            aibotes.Columns.Add("keyId", typeof(string));
            aibotes.Columns.Add("botName", typeof(string));
            aibotes.Columns.Add("runStatus", typeof(string));
            DataColumn[] cols = new DataColumn[] { aibotes.Columns["keyId"] };
            aibotes.PrimaryKey = cols;

            // 将数据源绑定到DataGridView控件上  
            dataGridView1.DataSource = aibotes;

        }

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            btn_startServer.Enabled = false;
            btn_stopServer.Enabled = true;
            t1 = new Thread(() =>
          {
              try
              {
                  AndroidServer.getInstance().Start().Wait();
              }
              catch (AggregateException ee)
              {
                  Trace.TraceError(ee.Message);
              }
          });
            t1.IsBackground = true;
            t1.Start();

            t2 = new Thread(() =>
            {
                try
                {
                    WinServer.getInstance().Start().Wait();
                }
                catch (AggregateException ee)
                {
                    Trace.TraceError(ee.Message);
                }
            });
            t2.IsBackground = true;
            t2.Start();

            t3 = new Thread(() =>
            {
                try
                {
                    WebServer.getInstance().Start().Wait();
                }
                catch (AggregateException ee)
                {
                    Trace.TraceError(ee.Message);
                }
            });
            t3.IsBackground = true;
            t3.Start();
        }

        private void btn_stopServer_Click(object sender, EventArgs e)
        {
            AndroidServer.getInstance().ShutdownGracefully();
            WinServer.getInstance().ShutdownGracefully();
            WebServer.getInstance().ShutdownGracefully();
            this.RemoveAllClient();
            btn_startServer.Enabled = true;
            btn_stopServer.Enabled = false;
        }

        public delegate void AddDelegate(String key);
        public void AddClient(String key)
        {
            DataRow row = aibotes.NewRow();
            row["keyId"] = key;
            aibotes.Rows.Add(row);
        }

        public void refushClient(String key, Aibote aibote)
        {
            DataRow? row = aibotes.Rows.Find(key);
            row["runStatus"] = aibote.runStatus;
            row["botName"] = aibote.GetScriptName();
        }

        public delegate void RemoveDelegate(String key);
        public void RemoveClient(String key)
        {
            DataRow? row = aibotes.Rows.Find(key);
            aibotes.Rows.Remove(row);
        }

        public void RemoveAllClient()
        {
            aibotes.Rows.Clear();
        }

        private void btn_select_script_Click(object sender, EventArgs e)
        {
            string? keyId = getSelectRowKeyId();
            if (keyId != null)
            {
                this.label2.Text = "选中了： " + keyId;
            }
        }
        private void btn_run_script_Click(object sender, EventArgs e)
        {
            string? keyId = getSelectRowKeyId();
            if (keyId != null)
            {
                _ = RunTaskIntAsync(keyId, getSelectScript());
            }
        }

        private string? getSelectRowKeyId()
        {
            var dataselect = this.dataGridView1.SelectedRows;
            if (dataselect.Count > 0)
            {
                DataGridViewRow row = dataselect[0];
                string? keyId = Convert.ToString(row.Cells["keyId"].Value);
                return keyId;
            }
            return null;
        }

        private Aibote getSelectScript()
        {
            Aibote aibote = new AndroidBotTest();
            return aibote;
        }

        private async Task<int> RunTaskIntAsync(string keyId, Aibote aibote)
        {
            int result = 0;
            AiboteChannel? aiboteChannel = AndroidClientManager.getInstance().get(keyId);
            if (aiboteChannel != null)
            {
                aiboteChannel.setAibote(aibote);
                if (aibote != null)
                {
                    aibote.runStatus = "运行中";
                    refushClient(keyId, aibote);
                    Task task = new Task(() =>
                    {
                        aibote.DoScript();
                    });
                    task.Start();
                    await task;
                    aibote.runStatus = "执行完成";
                    refushClient(keyId, aibote);
                }
            }
            return result;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                btn_run_script.Enabled = true;
            }
            else
            {
                btn_run_script.Enabled = false;
            }
        }
    }
}