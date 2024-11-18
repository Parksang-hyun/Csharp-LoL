using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace game00
{
    public partial class Form4 : Form
    {
        private Form1 _form1;

        private bool isButton8Clicked = false;
        private bool isButton9Clicked = false;
        private bool isButton10Clicked = false;
        private bool isButton11Clicked = false;
        private bool isButton12Clicked = false;
        private bool isButton13Clicked = false;
        private bool isButton14Clicked = false;

        public Form4(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(_form1);
            form3.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_form1);
            form2.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)      // 종료 버튼
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)      // 장착 버튼
        {
            if (isButton8Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.lol15);
            }

            if (isButton9Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.lol16);
            }

            if (isButton10Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.oo30_2);
            }

            if (isButton11Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.oo30_3);
            }

            if (isButton12Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.oo30_4);
            }

            if (isButton13Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.oo30_5);
            }

            if (isButton14Clicked)
            {
                _form1.SetButton3BackgroundImage(Properties.Resources.oo30_1);
            }

            _form1.Show();
            this.Close();
        }

        private void button8_MouseEnter(object sender, EventArgs e)     // 기본 폭탄 버튼 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.lol11;
        }

        private void button9_Click(object sender, EventArgs e)      // 불꽃놀이-사파이어 버튼 클릭
        {
            pictureBox1.Image = Properties.Resources.lol10;

            isButton8Clicked = false;
            isButton9Clicked = true;
            isButton10Clicked = false;
            isButton11Clicked = false;
            isButton12Clicked = false;
            isButton13Clicked = false;
            isButton14Clicked = false;
        }

        private void button9_MouseEnter(object sender, EventArgs e)      // 불꽃놀이-사파이어 버튼 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.lol10;
        }

        private void button8_Click(object sender, EventArgs e)      // 기본 폭탄 버튼 클릭
        {
            pictureBox1.Image = Properties.Resources.lol11;

            isButton8Clicked = true;
            isButton9Clicked = false;
            isButton10Clicked = false;
            isButton11Clicked = false;
            isButton12Clicked = false;
            isButton13Clicked = false;
            isButton14Clicked = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_2;

            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = true;
            isButton11Clicked = false;
            isButton12Clicked = false;
            isButton13Clicked = false;
            isButton14Clicked = false;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_2;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_3;
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_4;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_5;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_3;

            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = false;
            isButton11Clicked = true;
            isButton12Clicked = false;
            isButton13Clicked = false;
            isButton14Clicked = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_4;

            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = false;
            isButton11Clicked = false;
            isButton12Clicked = true;
            isButton13Clicked = false;
            isButton14Clicked = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_5;

            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = false;
            isButton11Clicked = false;
            isButton12Clicked = false;
            isButton13Clicked = true;
            isButton14Clicked = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.oo29_1;

            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton10Clicked = false;
            isButton11Clicked = false;
            isButton12Clicked = false;
            isButton13Clicked = false;
            isButton14Clicked = true;
        }
    }
}
