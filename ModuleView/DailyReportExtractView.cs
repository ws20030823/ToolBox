using DocumentFormat.OpenXml.Packaging;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace 工具箱.ModuleView
{
    public partial class DailyReportExtractView : UserControl
    {
        public DailyReportExtractView()
        {
            InitializeComponent();
        }
        // 选择文件夹并提取Word内容
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = fbd.SelectedPath;
                    string allWordContent = ExtractAllWordText(folderPath);

                    // 导出到TXT（保存到桌面）
                    string txtPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "日报汇总.txt");
                    File.WriteAllText(txtPath, allWordContent);

                    txtResult.Text = $"已提取所有Word内容，并保存到：{txtPath}\n\n{allWordContent}";
                }
            }
        }

        // 递归读取文件夹下所有Word（.docx）的文本内容
        private string ExtractAllWordText(string folderPath)
        {
            StringBuilder contentBuilder = new StringBuilder();
            // 获取所有.docx文件（包括子文件夹）
            string[] wordFiles = Directory.GetFiles(folderPath, "*.docx", SearchOption.AllDirectories);

            foreach (string filePath in wordFiles)
            {
                try
                {
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
                    {
                        // 修正：显式指定Body类型，避免命名冲突，并进行空值检查
                        var mainPart = wordDoc.MainDocumentPart;
                        if (mainPart != null && mainPart.Document != null && mainPart.Document.Body != null)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.Body;
                            // 添加文件信息和内容
                            contentBuilder.AppendLine($"=== 文件：{filePath} ===");
                            contentBuilder.AppendLine(body.InnerText);
                            contentBuilder.AppendLine("\n-------------------------\n");
                        }
                        else
                        {
                            contentBuilder.AppendLine($"读取文件失败：{filePath}，错误：文档结构不完整。");
                        }
                    }
                }
                catch (Exception ex)
                {
                    contentBuilder.AppendLine($"读取文件失败：{filePath}，错误：{ex.Message}");
                }
            }
            return contentBuilder.ToString();
        }
    }
}