using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具箱.ModuleView
{
    // 自定义点结构体，比Tuple更高效
    public struct Point3D
    {
        public float X;
        public float Y;
        public float Z;

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public partial class PointCloudConverterView : UserControl
    {
        private string inputFilePath = string.Empty;
        private string outputFilePath = string.Empty;

        public PointCloudConverterView()
        {
            InitializeComponent();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputFilePath = openFileDialog.FileName;
                    txtInputPath.Text = inputFilePath;
                    btnConvert.Enabled = !string.IsNullOrEmpty(inputFilePath);
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // 修改筛选器为TIFF格式
                saveFileDialog.Filter = "TIFF files (*.tif)|*.tif|TIFF files (*.tiff)|*.tiff";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(inputFilePath) + ".tif";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFilePath = saveFileDialog.FileName;
                    txtOutputPath.Text = outputFilePath;
                }
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("请选择输入文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(outputFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // 修改筛选器为TIFF格式
                    saveFileDialog.Filter = "TIFF files (*.tif)|*.tif|TIFF files (*.tiff)|*.tiff";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = Path.GetFileNameWithoutExtension(inputFilePath) + ".tif";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    outputFilePath = saveFileDialog.FileName;
                    txtOutputPath.Text = outputFilePath;
                }
            }

            btnConvert.Enabled = false;
            progressBar1.Visible = true;
            lblStatus.Text = "正在转换...";

            try
            {
                // 记录开始时间用于计算转换耗时
                var startTime = DateTime.Now;

                int pointCount = await ConvertTxtToTifAsync(inputFilePath, outputFilePath);

                var elapsedTime = DateTime.Now - startTime;
                lblStatus.Text = $"转换完成！耗时: {elapsedTime.TotalSeconds:F2}秒";
                MessageBox.Show($"转换成功完成！共处理{pointCount}个点，耗时{elapsedTime.TotalSeconds:F2}秒",
                              "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "转换失败";
                MessageBox.Show($"转换失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConvert.Enabled = true;
                progressBar1.Visible = false;
            }
        }

        private async Task<int> ConvertTxtToTifAsync(string inputPath, string outputPath)
        {
            // 一次性读取所有文本，比逐行读取更高效
            string allText = await File.ReadAllTextAsync(inputPath);

            // 按换行符分割，避免创建中间列表
            string[] lines = allText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // 预估容量，避免列表动态扩容的开销
            List<Point3D> points = new List<Point3D>(lines.Length);

            progressBar1.Maximum = lines.Length;
            progressBar1.Value = 0;

            // 进度更新间隔，避免过于频繁的UI更新
            int updateInterval = Math.Max(1, lines.Length / 100); // 最多更新100次

            // 第一步：读取所有有效点云数据
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine))
                    continue;

                // 使用快速分割方法
                string[] parts = trimmedLine.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 3)
                {
                    if (float.TryParse(parts[0], out float x) &&
                        float.TryParse(parts[1], out float y) &&
                        float.TryParse(parts[2], out float z))
                    {
                        points.Add(new Point3D(x, y, z));
                    }
                }

                // 按间隔更新进度条，减少UI交互开销
                if (i % updateInterval == 0)
                {
                    progressBar1.Value = i;
                    // 只在需要更新时才让出线程
                    await Task.Yield();
                }
            }

            // 确保进度条显示100%
            progressBar1.Value = lines.Length;

            if (points.Count == 0)
            {
                throw new InvalidDataException("未读取到有效的3D点云数据");
            }

            // 第二步：计算点云的边界（最大/最小X、Y、Z）
            float minX = points.Min(p => p.X);
            float maxX = points.Max(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxY = points.Max(p => p.Y);
            float minZ = points.Min(p => p.Z);
            float maxZ = points.Max(p => p.Z);

            // 定义图像尺寸（可根据需求调整，这里设为1024x1024，也可以根据点云范围动态计算）
            int imageWidth = 1024;
            int imageHeight = 1024;

            // 创建位图对象（24位真彩色，也可以用8位灰度图）
            Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(bitmap);
            // 填充背景为白色
            g.Clear(Color.White);

            // 第三步：将点云映射到图像像素，并根据Z值设置灰度
            foreach (var point in points)
            {
                // 将X、Y坐标归一化到0-1范围
                float normX = (point.X - minX) / (maxX - minX);
                float normY = (point.Y - minY) / (maxY - minY);

                // 映射到图像像素坐标（注意Y轴反转，因为图像的Y轴向下）
                int pixelX = (int)(normX * (imageWidth - 1));
                int pixelY = (int)((1 - normY) * (imageHeight - 1));

                // 将Z值归一化到0-255的灰度范围
                int grayValue = (int)((point.Z - minZ) / (maxZ - minZ) * 255);
                grayValue = Math.Clamp(grayValue, 0, 255); // 确保在0-255范围内

                // 设置像素颜色（灰度）
                Color color = Color.FromArgb(grayValue, grayValue, grayValue);
                bitmap.SetPixel(pixelX, pixelY, color);
            }

            // 第四步：保存为TIFF格式
            // 注意：需要使用ImageFormat.Tiff，并且处理异步保存（这里用Task.Run包装同步操作）
            await Task.Run(() =>
            {
                using (var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    bitmap.Save(fs, ImageFormat.Tiff);
                }
            });

            // 释放资源
            g.Dispose();
            bitmap.Dispose();

            return points.Count;
        }
    }
}