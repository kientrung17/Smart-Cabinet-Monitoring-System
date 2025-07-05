using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Nhap_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ad" && textBox2.Text == "1")

            {
                MessageBox.Show("Bạn đã đăng nhập thành công!");
                Form2 form2 = new Form2();

                // Đăng ký sự kiện khi Form2 đóng
                form2.FormClosed += (s, args) => this.Show();

                // Ẩn Form1 và hiển thị Form2
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu của bạn không đúng",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            { 
                textBox2.PasswordChar = '*';
            }
        }
    }
}
