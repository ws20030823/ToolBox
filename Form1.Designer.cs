namespace 工具箱
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
            TreeNode treeNode1 = new TreeNode("进程管理");
            TreeNode treeNode2 = new TreeNode("工作", new TreeNode[] { treeNode1 });
            TreeNode treeNode3 = new TreeNode("Null");
            TreeNode treeNode4 = new TreeNode("日常", new TreeNode[] { treeNode3 });
            treeView1 = new TreeView();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 0);
            treeView1.Margin = new Padding(2, 3, 2, 3);
            treeView1.Name = "treeView1";
            treeNode1.Name = "进程管理";
            treeNode1.Text = "进程管理";
            treeNode2.Name = "工作";
            treeNode2.Text = "工作";
            treeNode3.Name = "Null";
            treeNode3.Text = "Null";
            treeNode4.Name = "日常";
            treeNode4.Text = "日常";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode2, treeNode4 });
            treeView1.Size = new Size(121, 498);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(121, 0);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(688, 498);
            panel2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 498);
            Controls.Add(panel2);
            Controls.Add(treeView1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "v";
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private Panel panel2;
    }
}
