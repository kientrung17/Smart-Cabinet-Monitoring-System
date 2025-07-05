using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_bieudo5;
using System.Windows.Forms.DataVisualization.Charting;

namespace dothi_test2
{
    public partial class Form2 : Form
    {
        private List<List<double>> xValsList = new List<List<double>>();
        private List<List<double>> yValsList = new List<List<double>>();
        private double tick = 0.0;
        private Chart[] charts;
        private double[] tP;
        public double currentMaxY { get; private set; }
        public Form2(double[] tP)
        {
            InitializeComponent();

            this.tP = tP;
            charts = new Chart[] { chart1, chart2, chart3, chart4, chart5, chart6, chart7, chart8,
                               chart9, chart10, chart11, chart12, chart13, chart14, chart15, chart16 };
            Linegraph[] graphs = new Linegraph[16];

            for (int i = 0; i < charts.Length; i++)
            {
                graphs[i] = new Linegraph(charts[i], 0, 10, 1, 25, tP[i] + 2.0, 5, 3, 4);
            }
            for (int i = 0; i < 16; i++)
            {
                xValsList.Add(new List<double>());
                yValsList.Add(new List<double>());
            }
            ConfigStriplines(charts);
        }
        public void ConfigStriplines(Chart[] charts)
        {
            foreach (var chart in charts)
            {
                StripLine stripline = new StripLine
                {
                    StripWidth = 50,
                    Interval = 0,
                    IntervalOffset = 30.5,
                    BackColor = Color.FromArgb(120, Color.Red)
                };

                chart.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripline);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                xValsList[i].Add(tick);
                yValsList[i].Add(tP[i]);

                if (tick > 10.0)
                {
                    xValsList[i].RemoveAt(0);
                    yValsList[i].RemoveAt(0);
                }
                charts[i].ChartAreas["ChartArea1"].AxisX.Minimum = xValsList[i][0];
                charts[i].ChartAreas["ChartArea1"].AxisX.Maximum = tick;
                charts[i].ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                charts[i].ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true; // Bật hiển thị nhãn

                charts[i].ChartAreas["ChartArea1"].AxisY.Maximum = UpdateMaxY(tP[i]) + 1.0;
                charts[i].Series["Series1"].Points.DataBindXY(xValsList[i], yValsList[i]);
            }
            tick = tick + 1.0;
        }
        public double UpdateMaxY(double newValue)
        {
            return currentMaxY = Math.Max(currentMaxY, newValue);
        }
    }
}
