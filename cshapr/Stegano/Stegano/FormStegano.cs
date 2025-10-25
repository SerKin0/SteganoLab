using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stegano
{
    public partial class FormStegano : Form
    {
        public Image originalImage;

        public FormStegano()
        {
            InitializeComponent();
        }

        private void buttonDownloadImage_Click(object sender, EventArgs e)
        {
            FormChart chartForm = new FormChart();
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "Image Files|*.png;";

            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Загружаем изображение и сохраняем оригинал
                    originalImage = Image.FromFile(openPicture.FileName);
                    pictureBoxMain.Image = originalImage;
                    changeMode(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonGrayMode_Click(object sender, EventArgs e)
        {
            try
            {
                FormChart chartForm = new FormChart();
                Bitmap original = new Bitmap(pictureBoxMain.Image);
                Bitmap grayBitmap = new Bitmap(original.Width, original.Height);

                for (int x = 0; x < original.Width; x++)
                {
                    for (int y = 0; y < original.Height; y++)
                    {
                        Color originalColor = original.GetPixel(x, y);
                        int grayValue = (int)(originalColor.R * 0.299 +
                                             originalColor.G * 0.587 +
                                             originalColor.B * 0.114);
                        Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                        grayBitmap.SetPixel(x, y, grayColor);
                    }
                }

                // Используем существующую форму вместо создания новой
                chartForm.DisplayImage(grayBitmap);
                chartForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при преобразовании: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOriginalImage_Click(object sender, EventArgs e)
        {
            // Используем существующую форму вместо создания новой
            FormChart chartForm = new FormChart();
            chartForm.DisplayImage(originalImage);
            chartForm.Show();
        }

        private void buttonChannelHistogram_Click(object sender, EventArgs e)
        {
            if (pictureBoxMain.Image == null)
            {
                MessageBox.Show("Пожалуйста, сначала загрузите изображение.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FormChart chartForm = new FormChart();
                Bitmap bitmap = new Bitmap(originalImage);
                int[] rHist = new int[256];
                int[] gHist = new int[256];
                int[] bHist = new int[256];

                // Вычисляем гистограммы
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        rHist[pixel.R]++;
                        gHist[pixel.G]++;
                        bHist[pixel.B]++;
                    }
                }

                // Используем существующую форму
                chartForm.ClearChart();
                chartForm.SetTitle("Гистограммы каналов RGB");

                Chart chart = chartForm.GetChart();

                // Создаем три области для графиков
                ChartArea redArea = new ChartArea("RedArea");
                ChartArea greenArea = new ChartArea("GreenArea");
                ChartArea blueArea = new ChartArea("BlueArea");

                // Настраиваем области
                foreach (ChartArea area in new[] { redArea, greenArea, blueArea })
                {
                    area.AxisX.Title = "Интенсивность";
                    area.AxisY.Title = "Частота";
                    area.AxisX.Minimum = 0;
                    area.AxisX.Maximum = 255;
                    area.AxisX.Interval = 32;
                    area.Position.Width = 100; // Ширина области в %
                    area.Position.Height = 30; // Высота области в %
                    chart.ChartAreas.Add(area);
                }

                // Располагаем области
                redArea.Position.X = 0;
                redArea.Position.Y = 0;

                greenArea.Position.X = 0;
                greenArea.Position.Y = 33;

                blueArea.Position.X = 0;
                blueArea.Position.Y = 66;

                // Создаем серии
                Series redSeries = new Series("Красный")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.Red,
                    BorderWidth = 1
                };

                Series greenSeries = new Series("Зеленый")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.Green,
                    BorderWidth = 1
                };

                Series blueSeries = new Series("Синий")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.Blue,
                    BorderWidth = 1
                };

                // Заполняем данные
                for (int i = 0; i < 256; i++)
                {
                    redSeries.Points.AddXY(i, rHist[i]);
                    greenSeries.Points.AddXY(i, gHist[i]);
                    blueSeries.Points.AddXY(i, bHist[i]);
                }

                // Добавляем серии в соответствующие области
                chart.Series.Add(redSeries);
                chart.Series.Add(greenSeries);
                chart.Series.Add(blueSeries);

                redSeries.ChartArea = redArea.Name;
                greenSeries.ChartArea = greenArea.Name;
                blueSeries.ChartArea = blueArea.Name;

                // Настраиваем легенду
                chart.Legends.Clear();
                Legend legend = new Legend();
                chart.Legends.Add(legend);

                chartForm.Size = new Size(900, 600);
                chartForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении гистограммы: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GetBits(byte value)
        {
            byte[] bits = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                bits[7 - i] = (byte)((value >> i) & 1);
            }
            return bits;
        }

        private void buttonBitExtraction_Click(object sender, EventArgs e)
        {
            try
            {
                FormChart chartForm = new FormChart();
                Bitmap original = new Bitmap(pictureBoxMain.Image);
                Bitmap grayBitmap = new Bitmap(original.Width, original.Height);

                for (int x = 0; x < original.Width; x++)
                {
                    for (int y = 0; y < original.Height; y++)
                    {
                        Color originalColor = original.GetPixel(x, y);
                        string redBits = Convert.ToString(originalColor.R, 2).PadLeft(8, '0');
                        Color bit;
                        if (redBits[6] == '1') bit = Color.FromArgb(255, 255, 255);
                        else bit = Color.FromArgb(0, 0, 0);
                        grayBitmap.SetPixel(x, y, bit);
                    }
                }

                // Используем существующую форму вместо создания новой
                chartForm.DisplayImage(grayBitmap);
                chartForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при преобразовании: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLSB_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(pictureBoxMain.Image);
                int bitsPerChannel = 2;
                List<byte> bitList = new List<byte>();

                // Извлекаем биты
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        for (int channel = 0; channel < 3; channel++)
                        {
                            int value = channel == 0 ? pixel.R : channel == 1 ? pixel.G : pixel.B;
                            for (int i = bitsPerChannel - 1; i >= 0; i--)
                            {
                                bitList.Add((byte)((value >> i) & 1));
                            }
                        }
                    }
                }

                // Преобразуем биты в байты
                List<byte> byteData = new List<byte>();
                for (int i = 0; i < bitList.Count - 7; i += 8)
                {
                    byte val = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        val = (byte)((val << 1) | bitList[i + j]);
                    }
                    byteData.Add(val);
                }

                // Декодируем текст
                string result = string.Empty;
                string encodingUsed = string.Empty;
                try
                {
                    result = Encoding.UTF8.GetString(byteData.ToArray()).Split('\0')[0];
                    encodingUsed = "UTF-8";
                }
                catch
                {
                    result = "Не удалось декодировать данные.";
                    encodingUsed = "None";
                }

                // Сохраняем результат в файл
                string lsbOutputPath = "lsb_output.txt";
                File.WriteAllText(lsbOutputPath, result);
                MessageBox.Show($"Данные успешно декодированы! Сохранены в файл: {lsbOutputPath}.", "Декодировано Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровке LSB: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void test(object sender, EventArgs e)
        {
            if (pictureBoxMain.Image == null)
            {
                MessageBox.Show("Пожалуйста, сначала загрузите изображение.", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Bitmap bitmap = new Bitmap(pictureBoxMain.Image);
                int bitsPerChannel = 2; 
                List<byte> bitList = new List<byte>();

                // Извлекаем биты
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        for (int channel = 0; channel < 3; channel++)
                        {
                            int value = channel == 0 ? pixel.R : channel == 1 ? pixel.G : pixel.B;
                            for (int i = bitsPerChannel - 1; i >= 0; i--)
                            {
                                bitList.Add((byte)((value >> i) & 1));
                            }
                        }
                    }
                }

                // Преобразуем биты в байты
                List<byte> byteData = new List<byte>();
                for (int i = 0; i < bitList.Count - 7; i += 8)
                {
                    byte val = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        val = (byte)((val << 1) | bitList[i + j]);
                    }
                    byteData.Add(val);
                }

                // Декодируем текст
                string result = string.Empty;
                string encodingUsed = string.Empty;
                try
                {
                    result = Encoding.UTF8.GetString(byteData.ToArray()).Split('\0')[0];
                    encodingUsed = "UTF-8";
                }
                catch
                {
                    result = "Не удалось декодировать данные.";
                    encodingUsed = "None";
                }

                // Сохраняем результат в файл
                string lsbOutputPath = "lsb_output.txt";
                File.WriteAllText(lsbOutputPath, result);

                // Отображаем результат в FormChart с текстовым полем
                FormChart chartForm = new FormChart();
                Chart chart = chartForm.Controls.OfType<Chart>().First();
                chart.Series.Clear();
                chart.ChartAreas[0].AxisX.Title = "";
                chart.ChartAreas[0].AxisY.Title = "";
                chart.Text = "Результат LSB-декодирования";

                // Добавляем текстовую аннотацию
                TextAnnotation textAnnotation = new TextAnnotation
                {
                    Text = $"Декодированный текст ({encodingUsed}): {result}",
                    X = 10,
                    Y = 10,
                    Font = new Font("Arial", 12)
                };
                chart.Annotations.Add(textAnnotation);

                // Сохраняем пустой график с текстом
                string lsbChartPath = "lsb_result.png";
                chart.SaveImage(lsbChartPath, ChartImageFormat.Png);

                chartForm.ShowDialog();
                MessageBox.Show($"Декодированный текст ({encodingUsed}): {result}\nСохранено в {lsbOutputPath}", "Успех",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровке LSB: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeMode(bool mode = true)
        {
            buttonGrayMode.Enabled = mode;
            buttonChannelHistogram.Enabled = mode;
            buttonLSB.Enabled = mode;
            buttonOriginalImage.Enabled = mode;
            buttonBitExtraction.Enabled = mode;
        }
    }
}