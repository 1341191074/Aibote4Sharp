using Aibote4Sharp.scripts;
using Aibote4Sharp.sdk;
using System.Data;
using System.Diagnostics;

namespace Aibote4Sharp
{
    public partial class Form1 : Form
    {

        Thread? th;
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
            Thread th = new Thread(() =>
            {
                try
                {
                    AndroidServer.getInstance().Start().Wait();
                    WinServer.getInstance().Start().Wait();
                    WebServer.getInstance().Start().Wait();
                }
                catch (AggregateException ee)
                {
                    Trace.TraceError(ee.Message);
                }
            });
            th.IsBackground = true;
            th.Start();
        }

        private void btn_stopServer_Click(object sender, EventArgs e)
        {
            AndroidServer.getInstance().ShutdownGracefully();
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
            }
            return result;
        }
    }
}