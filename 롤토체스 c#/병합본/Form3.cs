using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static game00.Program;

namespace game00
{
    public partial class Form3 : Form
    {
        private Form1 _form1;

        private bool isButton1Clicked = false;
        private bool isButton4Clicked = false;
        private bool isButton8Clicked = false;
        private bool isButton9Clicked = false;
        private bool isButton10Clicked = false;

        public Form3(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_MouseEnter(object sender, EventArgs e)     // 기본 결투장 버튼 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.ll17;
        }

        private void button3_Click(object sender, EventArgs e)      // 전략가 버튼 클릭
        {
            Form2 form2 = new Form2(_form1);
            form2.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)      // 종료버튼
        {
            this.Close();
        }

        private void button4_MouseEnter(object sender, EventArgs e)     // 용 결투장 버튼 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.ll21;
        }

        private void button1_Click(object sender, EventArgs e)      // 기본 결투장 버튼 클릭
        {
            pictureBox1.Image = Properties.Resources.ll17;

            isButton1Clicked = true;
            isButton4Clicked = false;
            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = false;
        }

        private void button6_Click(object sender, EventArgs e)      // 장착 버튼 클릭
        {
            if (isButton1Clicked)
            {
                _form1.SetButton2BackgroundImage(Properties.Resources.ll7);
            }

            if (isButton4Clicked)
            {
                _form1.SetButton2BackgroundImage(Properties.Resources.ll24);
            }

            if (isButton8Clicked)
            {
                _form1.SetButton2BackgroundImage(Properties.Resources.oo35_1);
            }

            if (isButton9Clicked)
            {
                _form1.SetButton2BackgroundImage(Properties.Resources.oo35_2);
            }

            if (isButton10Clicked)
            {
                _form1.SetButton2BackgroundImage(Properties.Resources.oo35_3);
            }

            _form1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)      // 용의 결투장 클릭
        {
            pictureBox1.Image = Properties.Resources.ll21;
            SharedData.image = 1;
        }

        private void button7_Click(object sender, EventArgs e)      // 펑펑효과 클릭 버튼
        {
            Form4 form4 = new Form4(_form1);
            form4.Show();
            Hide();
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo34_1;
            SharedData.image = 2;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo34_2;
            SharedData.image = 3;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo34_3;
            SharedData.image = 4;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo34_1;

            isButton1Clicked = false;
            isButton4Clicked = false;
            isButton8Clicked = true;
            isButton9Clicked = false;
            isButton10Clicked = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo34_2;

            isButton1Clicked = false;
            isButton4Clicked = false;
            isButton8Clicked = false;
            isButton9Clicked = true;
            isButton10Clicked = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo34_3;

            isButton1Clicked = false;
            isButton4Clicked = false;
            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = true;
        }
    }
}
