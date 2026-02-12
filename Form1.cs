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
                case "提取日报内容": // 新增分支
                    DailyReportExtractView reportView = new DailyReportExtractView();
                    reportView.Dock = DockStyle.Fill;
                    panel2.Controls.Add(reportView);
                    break;
                case "点云转换":
                    PointCloudConverterView pointCloudConverterView = new PointCloudConverterView();
                    pointCloudConverterView.Dock = DockStyle.Fill;
                    panel2.Controls.Add(pointCloudConverterView);
                    break;
                default:
                    panel2.Controls.Clear(); break;
            }
        }
    }
}