using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace test_bieudo5
{
    internal class Linegraph
    {
        #region properties
        public double xAxisMax { get; set; }
        public double xAxisMin { get; set; }
        public double xAxisInterval { get; set; }
        public double yAxisMax { get; set; }
        public double yAxisMin { get; set; }
        public double yAxisInterval { get; set; }
        public double lineWidth { get; set; }
        public Color linecolor { get; set; }
        public double yMinorInt { get; set; }
        #endregion
        #region constructor
        public Linegraph(Chart chart1, double xAxismin, double xAxismax, double xAxisInterval,
                         double yAxismin, double yAxismax, double yAxisInterval, int lineWidth, int numMinorYGrid)
        {
            this.xAxisMin = xAxismin;
            this.xAxisMax = xAxismax;
            this.xAxisInterval = xAxisInterval;
            this.yAxisMin = yAxismin;
            this.yAxisMax = yAxismax;
            this.yAxisInterval = yAxisInterval;
            this.lineWidth = lineWidth;
            this.yMinorInt = yAxisInterval / (1.0 + numMinorYGrid);

            //chart1.Series["Series1"].ChartType = SeriesChartType.Spline;

            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = xAxismin;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = xAxismax;

            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = yAxismin;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = yAxismax;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = yAxisInterval;

            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.DarkGray;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = yMinorInt;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.Series["Series1"].BorderWidth = lineWidth;
            //chart1.Series["Series1"].ChartType = SeriesChartType.Spline;
            //chart1.Legends.Clear();

        }

        #endregion
    }
}
