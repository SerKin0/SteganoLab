using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stegano
{
    public partial class FormChart : Form
    {
        public FormChart()
        {
            InitializeComponent();
        }

        public void AddChart(ChartArea chartArea, Series series)
        {
            if (!chart1.ChartAreas.Contains(chartArea))
            {
                chart1.ChartAreas.Add(chartArea);
            }
            chart1.Series.Add(series);
            series.ChartArea = chartArea.Name;
        }

        public Chart GetChart()
        {
            return chart1;
        }

        public void AddCharts(Dictionary <ChartArea, Series> charts)
        {
            foreach (var chart in charts)
            {
                chart1.ChartAreas.Add(chart.Key);
                chart1.Series.Add(chart.Value);
                chart.Value.ChartArea = chart.Key.Name;
            }
        }

        public void ClearChart()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Annotations.Clear();
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }

        public void DisplayImage(Image image)
        {
            ClearChart();

            string temp_path = Path.GetTempFileName() + ".png";
            image.Save(temp_path, System.Drawing.Imaging.ImageFormat.Png);

            ChartArea area = new ChartArea();
            area.BackImage = temp_path;
            area.BackImageWrapMode = ChartImageWrapMode.Scaled;
            area.AxisX.Enabled = AxisEnabled.False;
            area.AxisY.Enabled = AxisEnabled.False;

            Series series = new Series();

            this.Size = new Size(image.Width, image.Height);

            AddChart(area, series);
            chart1.Show();
        }
    }
}
