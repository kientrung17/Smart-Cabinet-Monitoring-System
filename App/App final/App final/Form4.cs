using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using AxWMPLib;
using System.IO;
using System.Reflection;
using WMPLib;

namespace Nhap_7
{
    public partial class Form4 : Form
    {
        private Timer timer; // Bộ đếm thời gian để cập nhật số
        private int counter = 128; // Giá trị đếm
        public Form4()
        {
            InitializeComponent();
            this.ControlBox = false; // Ẩn toàn bộ các nút ControlBox (Minimize, Maximize, Close)
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none"; // Ẩn các nút bấm
            axWindowsMediaPlayer1.BackColor = System.Drawing.Color.White; // Nền màu trắng
            string videoPath = @"D:\DATN\Tu Tai Lieu\dongtu.mp4";
            // axWindowsMediaPlayer1.Ctlcontrols.play();
            // axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            // Cấu hình Timer
            timer1.Interval = 215; // 
            timer1.Tick += timer1_Tick; // Gắn sự kiện Timer
            timer1.Start(); // Bắt đầu Timer
            if (File.Exists(videoPath))
            {
                axWindowsMediaPlayer1.URL = videoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            }
            else
            {
                MessageBox.Show("File video không tồn tại!");
            }

        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close(); // Thoát ứng dụng khi video phát xong
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Tăng giá trị đếm
            if (counter >= 0)
            {
                label1.Text = $" {counter} cm";
                counter--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause(); // Dừng video
                timer1.Stop(); // Ngừng cập nhật thời gian
                button1.BackColor = Color.Red;
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play(); // Tiếp tục phát video
                timer1.Start(); // Tiếp tục cập nhật thời gian
                button1.BackColor = Color.Lime;
            }
        }
    }
}
