using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace 工具箱.ModuleView
{
    public partial class ProcessManagerView : UserControl
    {
        private List<ProcessInfo> processList = new List<ProcessInfo>();
        public ProcessManagerView()
        {
            InitializeComponent();
            InitializeEvents();
            LoadProcessList();
        }
        private void InitializeEvents()
        {
            //表格操作列点击事件
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            //搜索框获取焦点事件
            txtBoxSearch.GotFocus += txtBoxSearch_GotFocus;
            //搜索框失去焦点事件
            txtBoxSearch.LostFocus += txtBoxSearch_LostFocus;
            //搜索框功能实现
            txtBoxSearch.TextChanged += FilterProcesses;
        }

        private void LoadProcessList()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    ProcessInfo processInfo = new ProcessInfo
                    {
                        Name = process.ProcessName,
                        Id = process.Id,
                        MemoryUsage = process.PrivateMemorySize64.ToString(),
                        StartTime = process.StartTime.ToString()
                    };
                    processList.Add(processInfo);
                    dataGridView.Rows.Add(processInfo.Name, processInfo.Id, processInfo.MemoryUsage, processInfo.StartTime, "结束进程");
                }
                catch (Win32Exception)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    // 处理其他异常
                    MessageBox.Show($"获取进程 {process.ProcessName} 信息失败：{ex.Message}", "提示");
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "操作" && e.RowIndex >= 0)
            {
                DialogResult isEnd = MessageBox.Show("是否结束进程？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (isEnd == DialogResult.OK)
                {
                    try
                    {
                        //获取ID
                        var targetRow = dataGridView.Rows[e.RowIndex];
                        if (targetRow.Cells[1].Value == null)
                        {
                            MessageBox.Show("进程Id为空，无法结束");
                            return;
                        }
                        if (!int.TryParse(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(), out int id))
                        {
                            MessageBox.Show("进程ID格式错误！");
                            return;
                        }
                        if (id == Process.GetCurrentProcess().Id)
                        {
                            MessageBox.Show("不能结束当前进程！");
                            return;
                        }
                        Process targetProcess = Process.GetProcessById(id);
                        KillChildProcesses(targetProcess.Id);
                        targetProcess.Kill();
                        targetProcess.WaitForExit();
                        dataGridView.Rows.RemoveAt(e.RowIndex);
                        processList.RemoveAll(x => x.Id == id);
                        MessageBox.Show("进程已结束");
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("未找到指定进程");
                    }
                }
            }
        }
        /// <summary>
        /// 结束子进程
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void KillChildProcesses(int id)
        {
            string query = $"select * from Win32_Process where ParentProcessId = {id}";
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject childprocess in managementObjectSearcher.Get())
                { 
                    int childProcessId = (int)childprocess["ProcessId"];
                    KillChildProcesses(childProcessId);
                    try
                    {
                        Process currentProcess = Process.GetProcessById(childProcessId);
                        currentProcess.Kill();
                        currentProcess.WaitForExit();
                    }
                    catch
                    (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } 
        }

        private void txtBoxSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "输入进程名称搜索")
            {
                txtBoxSearch.Text = "";
            }
        }
        private void txtBoxSearch_LostFocus(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "")
            {
                txtBoxSearch.Text = "输入进程名称搜索";
            }
        }
        private void FilterProcesses(object sender, EventArgs e)
        {
            string searchText = txtBoxSearch.Text;
            if (searchText == "输入进程名称搜索" || searchText == "")
            {
                dataGridView.Rows.Clear();
                foreach (ProcessInfo process in processList)
                {
                    dataGridView.Rows.Add(process.Name, process.Id, process.MemoryUsage, process.StartTime, "结束进程");
                }

            }
            else
            {
                var filteredProcesses = processList.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
                dataGridView.Rows.Clear();
                foreach (var process in filteredProcesses)
                {
                    dataGridView.Rows.Add(process.Name, process.Id, process.MemoryUsage, process.StartTime, "结束进程");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            foreach (var process in processList)
            { 
                dataGridView.Rows.Add(process.Name, process.Id, process.MemoryUsage, process.StartTime, "结束进程");
            }
        }
    }
    public class ProcessInfo
    { 
        public string Name { get; set; }
        public int Id { get; set; }
        public string MemoryUsage { get; set; }
        public string StartTime { get; set; }
    }
}
