using 工具箱.ModuleView;

namespace 工具箱
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel2.Controls.Clear();
            switch (e.Node.Text) 
            {
                case "进程管理":
                    ProcessManagerView processManagerView = new ProcessManagerView();
                    processManagerView.Dock = DockStyle.Fill;
                    panel2.Controls.Add(processManagerView);
                    break;
                default:
                    panel2.Controls.Clear(); break;
            }
        }
    }
}
