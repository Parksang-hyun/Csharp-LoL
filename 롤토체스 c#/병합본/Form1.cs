using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game00
{
    public partial class Form1 : Form
    {
        private Image _fixedImage; // 고정된 이미지를 저장하는 변수
        public string LabelText { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      // 전략가 버튼 클릭
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)      // 결투장 버튼 클릭
        {
            Form3 form3 = new Form3(this);
            form3.Show();
            //Hide();
        }

        private void button3_Click(object sender, EventArgs e)      // 펑펑효과 버튼 클릭
        {
            Form4 form4 = new Form4(this);
            form4.Show();
            //this.Hide();
        }

        public void SetButton1BackgroundImage(Image image)     // 전략가 버튼 배경 강도깨비로 변경
        {
            button1.BackgroundImage = image; // ll23.png를 리소스에서 가져옴
        }

        private void OpenForm2()        // From2 열기
        {
            Form2 form2 = new Form2(this); // Form1의 인스턴스를 전달
            form2.Show();
        }

        public void SetButton2BackgroundImage(Image image)     // 전략가 버튼 배경 강도깨비로 변경
        {
            button2.BackgroundImage = image; // ll23.png를 리소스에서 가져옴
            _fixedImage = image;
        }

        private void OpenForm3()        // From2 열기
        {
            Form3 form3 = new Form3(this); // Form1의 인스턴스를 전달
            form3.Show();
        }

        public void SetButton3BackgroundImage(Image image)     // 전략가 버튼 배경 강도깨비로 변경
        {
            button3.BackgroundImage = image; // ll23.png를 리소스에서 가져옴
        }

        private void OpenForm4()        // From2 열기
        {
            Form4 form4 = new Form4(this); // Form1의 인스턴스를 전달
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ChangeButton1Background(int sequence)
        {
            switch (sequence)
            {
                case 1:
                    button1.BackgroundImage = Properties.Resources.oo16_2;
                    break;
                case 2:
                    button1.BackgroundImage = Properties.Resources.oo16_3;
                    break;
                case 3:
                    button1.BackgroundImage = Properties.Resources.oo16_4;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = LabelText;
            label3.Text = LabelText;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Start1 start1 = new Start1();
            start1.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Loby1 loby1 = new Loby1();
            loby1.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Shop shop1 = new Shop();
            shop1.Show();
            this.Close();
        }
    }
}
