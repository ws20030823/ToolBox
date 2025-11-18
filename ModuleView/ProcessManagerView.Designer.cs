namespace 工具箱.ModuleView
{
    partial class ProcessManagerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            进程名称 = new DataGridViewTextBoxColumn();
            进程ID = new DataGridViewTextBoxColumn();
            内存占用 = new DataGridViewTextBoxColumn();
            启动时间 = new DataGridViewTextBoxColumn();
            操作 = new DataGridViewButtonColumn();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtBoxSearch = new TextBox();
            labSearch = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsslProcessCount = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { 进程名称, 进程ID, 内存占用, 启动时间, 操作 });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 54);
            dataGridView.Margin = new Padding(2, 3, 2, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(622, 306);
            dataGridView.TabIndex = 0;
            // 
            // 进程名称
            // 
            进程名称.HeaderText = "进程名称";
            进程名称.MinimumWidth = 6;
            进程名称.Name = "进程名称";
            进程名称.Width = 125;
            // 
            // 进程ID
            // 
            进程ID.HeaderText = "进程ID";
            进程ID.MinimumWidth = 6;
            进程ID.Name = "进程ID";
            进程ID.Width = 125;
            // 
            // 内存占用
            // 
            内存占用.HeaderText = " 内存占用";
            内存占用.MinimumWidth = 6;
            内存占用.Name = "内存占用";
            内存占用.Width = 125;
            // 
            // 启动时间
            // 
            启动时间.HeaderText = "启动时间";
            启动时间.MinimumWidth = 6;
            启动时间.Name = "启动时间";
            启动时间.Width = 125;
            // 
            // 操作
            // 
            操作.HeaderText = "操作";
            操作.MinimumWidth = 6;
            操作.Name = "操作";
            操作.Width = 125;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBoxSearch);
            panel1.Controls.Add(labSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(622, 54);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(497, 18);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 4;
            label3.Text = "刷新";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(396, 18);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(80, 17);
            label2.TabIndex = 3;
            label2.Text = "结束选中进程";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 2;
            label1.Text = "查看进程详情";
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.Location = new Point(58, 15);
            txtBoxSearch.Margin = new Padding(2, 3, 2, 3);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.Size = new Size(226, 23);
            txtBoxSearch.TabIndex = 1;
            txtBoxSearch.Text = "输入进程名称搜索";
            // 
            // labSearch
            // 
            labSearch.AutoSize = true;
            labSearch.Location = new Point(17, 18);
            labSearch.Margin = new Padding(2, 0, 2, 0);
            labSearch.Name = "labSearch";
            labSearch.Size = new Size(32, 17);
            labSearch.TabIndex = 0;
            labSearch.Text = "搜索";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tsslProcessCount });
            statusStrip1.Location = new Point(0, 360);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 11, 0);
            statusStrip1.Size = new Size(622, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(56, 17);
            toolStripStatusLabel1.Text = "进程总数";
            // 
            // tsslProcessCount
            // 
            tsslProcessCount.Name = "tsslProcessCount";
            tsslProcessCount.Size = new Size(15, 17);
            tsslProcessCount.Text = "1";
            // 
            // ProcessManagerView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "ProcessManagerView";
            Size = new Size(622, 382);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Panel panel1;
        private StatusStrip statusStrip1;
        private DataGridViewTextBoxColumn 进程名称;
        private DataGridViewTextBoxColumn 进程ID;
        private DataGridViewTextBoxColumn 内存占用;
        private DataGridViewTextBoxColumn 启动时间;
        private DataGridViewButtonColumn 操作;
        private Label labSearch;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtBoxSearch;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tsslProcessCount;
    }
}