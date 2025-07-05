using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using dothi_test2;

namespace Nhap_7
{
    public partial class Form2 : Form
    {
        public int laser;
        public int velocity;
        public double[] tP = new double[16];
        public double alarm = 0;
        public Form2()
        {
            InitializeComponent();
            button3.Visible = false;
            label1.Text = "Tủ đóng";
            label3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            // Tạo một instance của Form2 từ dự án dothi_test2
            dothi_test2.Form1 form2 = new dothi_test2.Form1();

            form2.DataReceived += Form2_DataReceived;
            // Hiển thị Form2
            form2.Show();
        }
        private void Form2_DataReceived(object sender, DataEventArgs e)
        {
            // Sử dụng Invoke để đảm bảo các thay đổi được thực hiện trên UI thread
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Form2_DataReceived(sender, e)));
                return;
            }

            // Xử lý dữ liệu khi sự kiện được gọi
            laser = e.Laser;
            velocity = e.Velocity;
            tP = e.TP;
            alarm = 0; // Đặt lại giá trị alarm trước khi tính toán
            for (int i = 0; i < 16; i++)
            {
                alarm += tP[i];
            }

            if (alarm == 0)
            {
                // Đèn xanh
                panel1.BackColor = Color.Lime;
                label4.Text = "Không có người";
                button3.Enabled = true;
            }
            else
            {
                // Đèn đỏ
                panel1.BackColor = Color.Red;
                label4.Text = "Có người";
                button3.Enabled = false;
            }

 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "A")
            {
                label3.Text = " Sách ở tủ 1 ô số 2";
                button2.Visible = false;
                button3.Visible = true;
                Form3 form3 = new Form3();

                // Đăng ký sự kiện khi Form2 đóng
                form3.FormClosed += (s, args) => this.Show();

                // Ẩn Form1 và hiển thị Form2
                this.Hide();
                form3.Show();
                label1.Text = "Tủ mở";

            }
            else
            {
                MessageBox.Show("Kho hiện không có tài liệu này");
                textBox1.Text = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            textBox1.Text = "";
            button2.Visible = true;
            button3.Visible = false;
            Form4 form4 = new Form4();

            // Đăng ký sự kiện khi Form2 đóng
            form4.FormClosed += (s, args) => this.Show();

            // Ẩn Form1 và hiển thị Form2
            this.Hide();
            form4.Show();
            label1.Text = "Tủ đóng";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;


}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
