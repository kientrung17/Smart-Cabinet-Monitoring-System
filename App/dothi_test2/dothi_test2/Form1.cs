using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using test_bieudo5;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;

namespace dothi_test2
{
 
    public partial class Form1 : Form
    {

        List<double> xVals = new List<double>();
        List<double> yLaserVals = new List<double>();
        List<double> ySpeedVals = new List<double>();
        List<double> yXaccelVals = new List<double>();
        List<double> yYaccelVals = new List<double>();
        List<double> yZaccelVals = new List<double>();
        List<double> yAaccelVals = new List<double>();

        public Random rnd = new Random();
        public int[] data = new int[22];
        //uint[] data = new uint[21];
        public int laser;
        public int velocity;
        public double[] tP = new double[16];
        public double[] alarm = new double[16];
        //public int data;
        double tick = 0.0;
        double counttick = 0;
        public double xAccel,yAccel,zAccel,aAccel;
        public double currentMaxY { get; private set; }
        public double currentMinY { get; private set; }

        public event EventHandler<DataEventArgs> DataReceived;


        public Form1()
        {
            InitializeComponent();
            string[] baudrate = { "9600", "14400", "19200", "56000", "57600", "115200" };
            comboBoxBaud.Items.AddRange(baudrate);
            serCOM = new SerialPort();
            serCOM.DataReceived += serCOM_DataReceived;
            Linegraph graph3 = new Linegraph(chart3, 0, 10, 1, 0, 100, 20, 1, 1);
            if (chart3.Titles.Count == 0)
            {
                chart3.Titles.Add("Đồ thị vận tốc theo thời gian");
                chart3.Titles[0].Font = new Font("Times New Roman", 12, FontStyle.Regular);
            }

            chart3.Legends.Clear();
            chart3.Series.Clear();
            var series3 = new Series
            {
                Name = "Series1",
                ChartType = SeriesChartType.Spline, // Thiết lập kiểu đồ thị là Spline
                BorderWidth = 2
            };
            chart3.Series.Add(series3);
            Linegraph graph1 = new Linegraph(chart1, 0, 10, 1, 0, 1400, 200, 1, 1);
            if (chart1.Titles.Count == 0)
            {
                chart1.Titles.Add("Đồ thị quãng đường theo thời gian");
                chart1.Titles[0].Font = new Font("Times New Roman", 12, FontStyle.Regular);
            }
            chart1.Legends.Clear();
            chart1.Series.Clear();
            var series1 = new Series
            {
                Name = "Series1",
                ChartType = SeriesChartType.Spline, // Thiết lập kiểu đồ thị là Spline
                BorderWidth = 2
            };
            chart1.Series.Add(series1);
            //configstripline();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxPort.DataSource = SerialPort.GetPortNames();
            comboBoxBaud.Text = "115200";
        }
        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (serCOM.BytesToRead >= 88)
                {
                    byte[] buffer = new byte[88];
                    int bytesRead = serCOM.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 88)
                    {
                        //Buffer.BlockCopy(buffer, 0, data, 0, buffer.Length);


                        for (int i = 0; i < 22; i++)
                        {
                            data[i] = BitConverter.ToInt32(buffer, i * 4); // Mỗi phần tử chiếm 4 byte
                        }

                        // kiểm tra vị trí 
                        int vtStart = Array.IndexOf(data, 65530);
                        laser = 10 * data[(vtStart + 1) % 22] -380 ;
                        velocity = 10 * data[(vtStart + 21) % 22];



                        for (int i = 0; i < 16; i++)
                        {
                            tP[i] = data[(vtStart + i + 2) % 22] / 10.0;
                            if (tP[i] > 80 && tP[i] < 0) tP[i] = 0;
                            if (tP[i] > 21) alarm[i] = 1;
                            else alarm[i] = 0;
                        }
                        xAccel = ((data[(vtStart + 18) % 22]) / 32768.0) * 16;
                        yAccel = ((data[(vtStart + 19) % 22]) / 32768.0) * 16;
                        zAccel = ((data[(vtStart + 20) % 22]) / 32768.0) * 16;
                        aAccel = Math.Sqrt(xAccel * xAccel + yAccel * yAccel + zAccel * zAccel);

                        // Gọi sự kiện DataReceived để truyền dữ liệu
                        DataReceived?.Invoke(this, new DataEventArgs(laser, velocity, alarm
                            ));
                        // Cập nhật TextBox với toàn bộ dữ liệu
                        this.Invoke(new Action(() =>
                        {
                            txbrx.Text = string.Join(" ", data) + Environment.NewLine
                            + "giá trị laser : " + string.Join(" ", laser) + Environment.NewLine + "giá trị gia tốc trục X : "
                            + string.Join(" ", xAccel) + Environment.NewLine + "giá trị gia tốc trục Y : "
                            + string.Join(" ", yAccel) + Environment.NewLine + "giá trị gia tốc trục Z : "
                            + string.Join(" ", zAccel) + Environment.NewLine + "giá trị gia tổng hợp |a| : "
                            + string.Join(" ", aAccel) + Environment.NewLine;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    int byteCount = serCOM.BytesToRead;
        //    byte[] buffer = new byte[byteCount];

        //    serCOM.Read(buffer, 0, byteCount);

        //    // Chuyển đổi buffer thành mảng int32
        //    int[] intArray = new int[byteCount / 4];
        //    Buffer.BlockCopy(buffer, 0, intArray, 0, byteCount);

        //    this.Invoke(new Action(() =>
        //    {
        //        foreach (int i in intArray)
        //        {
        //            txbrx.Text += i.ToString() + " ";
        //        }
        //    }));
        //}


        #region Button
        private void btnexit_Click(object sender, EventArgs e)
        {
            serCOM.Close();
            Application.Exit();
        }
        private void btnconnect_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (!serCOM.IsOpen)
            {
                
                // kiem tra cong Port
                if (!System.IO.Ports.SerialPort.GetPortNames().Contains(comboBoxPort.Text))
                {
                    MessageBox.Show("Chưa kết nối cổng COM");
                    return;
                }

                serCOM.PortName = comboBoxPort.Text;
                serCOM.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                serCOM.Open();

                btnconnect.Text = "Disconnected";
            }
            else
            {
                serCOM.Close();
                btnconnect.Text = "Connected";
            }
        }
        private void btnimu_Click(object sender, EventArgs e)
        {
            //serCOM.Write("imu");
            chart1.Visible = false;
            chart2.Visible = true;
            chart3.Visible = false;
            tableLayoutPanel1.Visible = false;
            pictureBox1.Visible = false;

            Linegraph graph1 = new Linegraph(chart2, 0, 10, 1, -2, 2, 0.5, 3, 2);
        }
        private void btnir_Click(object sender, EventArgs e)
        {
            //serCOM.Write("ir");
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            tableLayoutPanel1.Visible = true;
            pictureBox1.Visible = true;
            btnquangduong.Visible = false;
            btnvantoc.Visible = false;

        }
        private void btnlaser_Click(object sender, EventArgs e)
        {
            btnvantoc.Visible = true;
            btnquangduong.Visible = true;
            //serCOM.Write("laser");
            chart1.Visible = true;
            chart2.Visible = false;
            tableLayoutPanel1.Visible = false;
            pictureBox1.Visible = false;

        }
        private void btnsend_Click(object sender, EventArgs e)
        {
            string dulieu = txbsend.Text;
            if (serCOM.IsOpen) serCOM.Write(dulieu);
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txbrx.Text = "";
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;

            tableLayoutPanel1.Visible = true;
        }
        private void btngraph_Click(object sender, EventArgs e)
        {
            // Tạo một instance của Form2
            Form2 form2 = new Form2(tP);
            // Hiển thị Form2
            form2.Show();
        }
        private void btnvantoc_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = true;
            tableLayoutPanel1.Visible = false;
            pictureBox1.Visible = false;

        }

        private void btnquangduong_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart2.Visible = false;
            chart3.Visible = false;
            tableLayoutPanel1.Visible = false;
            pictureBox1.Visible = false;


        }
        #endregion

        #region TextBox
        private void txbsend_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        public void configstripline()
        {
            // config new strip line to hightligt portion of Y axis
            StripLine stripline1 = new StripLine();
            stripline1.StripWidth = 50;// width of strip line in actual Y axis value
            stripline1.Interval = 0; // draw strip line only once
            stripline1.IntervalOffset = 32; // location of bottom edge of strip in actual Y values
            stripline1.BackColor = Color.FromArgb(120, Color.Red);

            // add the strip line to the chart
            chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripline1);
        }
        private List<double> ApplyMovingAverage(List<double> data, int windowSize)
        {
            List<double> smoothedData = new List<double>();
            for (int i = 0; i < data.Count; i++)
            {
                double sum = 0;
                int count = 0;

                for (int j = i; j >= 0 && j > i - windowSize; j--)
                {
                    sum += data[j];
                    count++;
                }

                smoothedData.Add(sum / count);
            }
            return smoothedData;
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            double min = (xAccel < yAccel) ? ((xAccel < zAccel) ? xAccel : zAccel) : ((yAccel < zAccel) ? yAccel : zAccel);

            xVals.Add(tick);
            yLaserVals.Add(laser);
            ySpeedVals.Add(velocity);
            yXaccelVals.Add(xAccel);
            yYaccelVals.Add(yAccel);
            yZaccelVals.Add(zAccel);
            yAaccelVals.Add(aAccel);
            //yVals.Add(rnd.NextDouble());

            if (tick > 500)
            {
                xVals.RemoveAt(0);
                yLaserVals.RemoveAt(0);
                ySpeedVals.RemoveAt(0);
                yXaccelVals.RemoveAt(0);
                yYaccelVals.RemoveAt(0);
                yZaccelVals.RemoveAt(0);
                yAaccelVals.RemoveAt(0);
            }
            var smoothedLaserVals = ApplyMovingAverage(yLaserVals, 5);
            var smoothedSpeedVals = ApplyMovingAverage(ySpeedVals, 20);

            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = xVals[0];
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = tick;

            chart1.Series["Series1"].Points.DataBindXY(xVals, smoothedLaserVals);

            chart3.ChartAreas["ChartArea1"].AxisX.Minimum = xVals[0];
            chart3.ChartAreas["ChartArea1"].AxisX.Maximum = tick;

            chart3.Series["Series1"].Points.DataBindXY(xVals, smoothedSpeedVals);

            chart2.ChartAreas["ChartArea1"].AxisX.Minimum = xVals[0];
            chart2.ChartAreas["ChartArea1"].AxisX.Maximum = tick;

            //chart2.ChartAreas["ChartArea1"].AxisY.Maximum = UpdateMaxY(aAccel) + 0.2;
            //chart2.ChartAreas["ChartArea1"].AxisY.Minimum = UpdateMinY(min) - 0.2;
            chart2.Series["Series1"].Points.DataBindXY(xVals, yXaccelVals);
            chart2.Series["Series2"].Points.DataBindXY(xVals, yYaccelVals);
            chart2.Series["Series2"].BorderWidth = 3;
            chart2.Series["Series3"].Points.DataBindXY(xVals, yZaccelVals);
            chart2.Series["Series3"].BorderWidth = 3;
            chart2.Series["Series4"].Points.DataBindXY(xVals, yAaccelVals);
            chart2.Series["Series4"].BorderWidth = 3;

            chart1.Annotations.Clear();
            chart2.Annotations.Clear();
            chart3.Annotations.Clear();

            double lastXPos = xVals.Last();
            var lastX = yXaccelVals.Last();
            var lastY = yYaccelVals.Last();
            var lastZ = yZaccelVals.Last();
            var lastA = yAaccelVals.Last();
            var lastLaser = yLaserVals.Last();
            var lastSpeed = ySpeedVals.Last();
            // Thêm Annotation cho Laser
            var annotationLaser = new TextAnnotation
            {
                Text = $"Distance: {(int)lastLaser}",
                ForeColor = Color.Blue,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AnchorX = lastXPos,
                AnchorY = lastLaser + 0.05,
                AnchorDataPoint = chart1.Series["Series1"].Points.Last(),
                Alignment = ContentAlignment.MiddleLeft
            };
            chart1.Annotations.Add(annotationLaser);
            var annotationSpeed = new TextAnnotation
            {
                Text = $"velocity: {(int)lastSpeed}",
                ForeColor = Color.Blue,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AnchorX = lastXPos,
                AnchorY = lastSpeed + 0.05,
                AnchorDataPoint = chart3.Series["Series1"].Points.Last(),
                Alignment = ContentAlignment.MiddleLeft
            };
            chart3.Annotations.Add(annotationSpeed);
            // Thêm Annotation cho X
            var annotationX = new TextAnnotation
            {
                Text = $"X: {lastX:F2}",
                ForeColor = Color.Red,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AnchorX = lastXPos,
                AnchorY = lastX + 0.05,
                AnchorDataPoint = chart2.Series["Series1"].Points.Last(),
                Alignment = ContentAlignment.MiddleLeft
            };
            chart2.Annotations.Add(annotationX);

            // Thêm Annotation cho Y
            var annotationY = new TextAnnotation
            {
                Text = $"Y: {lastY:F2}",
                ForeColor = Color.Green,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AnchorX = lastXPos,
                AnchorY = lastY + 0.05,
                AnchorDataPoint = chart2.Series["Series2"].Points.Last(),
                Alignment = ContentAlignment.MiddleLeft
            };
            chart2.Annotations.Add(annotationY);

            // Thêm Annotation cho Z
            var annotationZ = new TextAnnotation
            {
                Text = $"Z: {lastZ:F2}",
                ForeColor = Color.Blue,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AnchorX = lastXPos,
                AnchorY = lastZ + 0.1,
                AnchorDataPoint = chart2.Series["Series3"].Points.Last(),
                Alignment = ContentAlignment.MiddleLeft
            };
            chart2.Annotations.Add(annotationZ);

            // Thêm Annotation cho |a|
            var annotationA = new TextAnnotation
            {
                Text = $"|a|: {lastA:F2}",
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AnchorX = lastXPos,
                AnchorY = lastA,
                AnchorDataPoint = chart2.Series["Series4"].Points.Last(),
                Alignment = ContentAlignment.MiddleLeft
            };
            chart2.Annotations.Add(annotationA);

            for (int i = 0; i < 16; i++)
            {
                Label label = this.Controls.Find($"label{i + 1}", true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = tP[i].ToString();
                    // Thay đổi màu sắc của label dựa trên giá trị nhiệt độ
                    if (tP[i] < 23.0) // Nhiệt độ dưới 30 độ
                    {
                        label.BackColor = Color.LightGreen;
                    }
                    else if (tP[i] >= 23.0 && tP[i] < 26.0) // Nhiệt độ từ 30 đến dưới 32 độ
                    {
                        label.BackColor = Color.Yellow;
                    }
                    else if (tP[i] >= 26.0 && tP[i] < 28.0)// Nhiệt độ từ 32-34
                    {
                        label.BackColor = Color.Orange;
                    }
                    else
                    {
                        label.BackColor = Color.Red;
                    }
                }
            }

            tick = tick + 1.0;

        }
        public double UpdateMaxY(double newValue)
        {
            // Kiểm tra nếu newValue lớn hơn currentMaxY, cập nhật currentMaxY
            if (newValue > currentMaxY)
            {
                currentMaxY = newValue;
            }
            currentMaxY = Math.Ceiling(newValue / 0.2) * 0.2;
            return currentMaxY;
        }

        public double UpdateMinY(double newValue)
        {
            // Kiểm tra nếu newValue lớn hơn currentMaxY, cập nhật currentMaxY
            if (newValue < currentMinY)
            {
                currentMinY = newValue;
            }
            currentMinY = Math.Floor(newValue / 0.2) * 0.2;
            return currentMinY;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
