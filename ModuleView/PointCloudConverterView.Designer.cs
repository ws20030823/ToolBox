namespace 工具箱.ModuleView
{
    partial class PointCloudConverterView
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
            this.SuspendLayout();

            // 创建控件
            Label lblInput = new Label();
            Label lblOutput = new Label();
            this.txtInputPath = new TextBox();
            this.txtOutputPath = new TextBox();
            this.btnBrowseInput = new Button();
            this.btnBrowseOutput = new Button();
            this.btnConvert = new Button();
            this.progressBar1 = new ProgressBar();
            this.lblStatus = new Label();

            // 设置控件属性
            lblInput.Text = "输入文件:";
            lblInput.Location = new Point(10, 10);
            lblInput.Size = new Size(100, 20);

            lblOutput.Text = "输出文件:";
            lblOutput.Location = new Point(10, 50);
            lblOutput.Size = new Size(100, 20);

            this.txtInputPath.Location = new Point(120, 10);
            this.txtInputPath.Size = new Size(300, 23);
            this.txtInputPath.ReadOnly = true;

            this.txtOutputPath.Location = new Point(120, 50);
            this.txtOutputPath.Size = new Size(300, 23);
            this.txtOutputPath.ReadOnly = true;

            this.btnBrowseInput.Text = "浏览...";
            this.btnBrowseInput.Location = new Point(430, 10);
            this.btnBrowseInput.Size = new Size(80, 23);
            this.btnBrowseInput.Click += new EventHandler(this.btnBrowseInput_Click);

            this.btnBrowseOutput.Text = "浏览...";
            this.btnBrowseOutput.Location = new Point(430, 50);
            this.btnBrowseOutput.Size = new Size(80, 23);
            this.btnBrowseOutput.Click += new EventHandler(this.btnBrowseOutput_Click);

            this.btnConvert.Text = "转换";
            this.btnConvert.Location = new Point(120, 90);
            this.btnConvert.Size = new Size(100, 30);
            this.btnConvert.Enabled = false;
            this.btnConvert.Click += new EventHandler(this.btnConvert_Click);

            this.progressBar1.Location = new Point(120, 130);
            this.progressBar1.Size = new Size(390, 23);
            this.progressBar1.Visible = false;

            this.lblStatus.Text = "";
            this.lblStatus.Location = new Point(120, 160);
            this.lblStatus.Size = new Size(390, 20);

            // 添加控件到用户控件
            this.Controls.Add(lblInput);
            this.Controls.Add(lblOutput);
            this.Controls.Add(this.txtInputPath);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStatus);

            // 设置用户控件属性
            this.Size = new Size(550, 200);
            this.ResumeLayout(false);
        }

        private TextBox txtInputPath;
        private TextBox txtOutputPath;
        private Button btnBrowseInput;
        private Button btnBrowseOutput;
        private Button btnConvert;
        private ProgressBar progressBar1;
        private Label lblStatus;
    }

    #endregion
}