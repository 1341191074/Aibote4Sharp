namespace Aibote4Sharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btn_startServer = new Button();
            btn_stopServer = new Button();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            keyId = new DataGridViewTextBoxColumn();
            botName = new DataGridViewTextBoxColumn();
            runStatus = new DataGridViewTextBoxColumn();
            aiboteClientManagerBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            btn_select_script = new Button();
            btn_run_script = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aiboteClientManagerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btn_startServer
            // 
            btn_startServer.Location = new Point(88, 628);
            btn_startServer.Name = "btn_startServer";
            btn_startServer.Size = new Size(146, 73);
            btn_startServer.TabIndex = 0;
            btn_startServer.Text = "启动服务器";
            btn_startServer.UseVisualStyleBackColor = true;
            btn_startServer.Click += btn_startServer_Click;
            // 
            // btn_stopServer
            // 
            btn_stopServer.Location = new Point(372, 628);
            btn_stopServer.Name = "btn_stopServer";
            btn_stopServer.Size = new Size(172, 73);
            btn_stopServer.TabIndex = 1;
            btn_stopServer.Text = "停止服务器";
            btn_stopServer.UseVisualStyleBackColor = true;
            btn_stopServer.Click += btn_stopServer_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(90, 17);
            label2.TabIndex = 5;
            label2.Text = "当前链接 {x} 个";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(12, 52);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1398, 507);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1390, 473);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "安卓";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { keyId, botName, runStatus });
            dataGridView1.DataSource = aiboteClientManagerBindingSource;
            dataGridView1.Location = new Point(19, 15);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(901, 438);
            dataGridView1.TabIndex = 0;
            // 
            // keyId
            // 
            keyId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            keyId.DataPropertyName = "keyId";
            keyId.HeaderText = "ID号";
            keyId.Name = "keyId";
            keyId.ReadOnly = true;
            keyId.Width = 68;
            // 
            // botName
            // 
            botName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            botName.DataPropertyName = "botName";
            botName.HeaderText = "名称";
            botName.Name = "botName";
            botName.ReadOnly = true;
            botName.Width = 67;
            // 
            // runStatus
            // 
            runStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            runStatus.DataPropertyName = "runStatus";
            runStatus.HeaderText = "运行状态";
            runStatus.Name = "runStatus";
            runStatus.ReadOnly = true;
            runStatus.Width = 99;
            // 
            // aiboteClientManagerBindingSource
            // 
            aiboteClientManagerBindingSource.DataSource = typeof(sdk.AndroidClientManager);
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1390, 473);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "windows";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 30);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1390, 473);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Web";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_select_script
            // 
            btn_select_script.Location = new Point(1133, 658);
            btn_select_script.Name = "btn_select_script";
            btn_select_script.Size = new Size(110, 34);
            btn_select_script.TabIndex = 7;
            btn_select_script.Text = "选择脚本";
            btn_select_script.UseVisualStyleBackColor = true;
            btn_select_script.Click += btn_select_script_Click;
            // 
            // btn_run_script
            // 
            btn_run_script.Location = new Point(1133, 724);
            btn_run_script.Name = "btn_run_script";
            btn_run_script.Size = new Size(110, 32);
            btn_run_script.TabIndex = 8;
            btn_run_script.Text = "运行脚本";
            btn_run_script.UseVisualStyleBackColor = true;
            btn_run_script.Click += btn_run_script_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1543, 794);
            Controls.Add(btn_run_script);
            Controls.Add(btn_select_script);
            Controls.Add(tabControl1);
            Controls.Add(label2);
            Controls.Add(btn_stopServer);
            Controls.Add(btn_startServer);
            Name = "Form1";
            Text = "Aibote中控";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)aiboteClientManagerBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_startServer;
        private Button btn_stopServer;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private BindingSource aiboteClientManagerBindingSource;
        private Button btn_select_script;
        private Button btn_run_script;
        private DataGridViewTextBoxColumn keyId;
        private DataGridViewTextBoxColumn botName;
        private DataGridViewTextBoxColumn runStatus;
        private TabPage tabPage3;
    }
}