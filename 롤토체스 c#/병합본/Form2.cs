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
using static System.Windows.Forms.DataFormats;

namespace game00
{
    public partial class Form2 : Form
    {
        private Form1 _form1;
        private Purchase1 _purchase1;
        private Purchase2 _purchase2;
        private Purchase3 _purchase3;
        private Purchase4 _purchase4;

        // 버튼 순서를 저장할 리스트
        private List<int> buttonSequence = new List<int>();

        private bool isButton1Clicked = false;
        private bool isButton3Clicked = false;
        private bool isButton8Clicked = false;
        private bool isButton9Clicked = false;
        private bool isButton6Clicked = false;

        private bool isButton10Clicked = false;
        private bool isButton11Clicked = false;
        private bool isButton12Clicked = false;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1; // Form1 인스턴스 저장
        }

        private void button1_MouseEnter(object sender, EventArgs e)     // 돌돌이 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.oo18_1;
        }

        private void button3_MouseEnter(object sender, EventArgs e)     // 얼음정수돌돌이 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.oo19_1;
        }

        private void button4_Click(object sender, EventArgs e)      // 결투장 스킨 버튼 클릭
        {
            Form3 form3 = new Form3(_form1);
            form3.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)      // 종료버튼
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)      // 돌돌이 클릭
        {
            pictureBox1.Image = Properties.Resources.oo18_1;

            isButton1Clicked = true;
            isButton3Clicked = false;
            isButton8Clicked = false;
            isButton9Clicked = false;
        }

        private void button6_Click(object sender, EventArgs e)      // 장착버튼
        {
            if (isButton1Clicked)
            {
                _form1.SetButton1BackgroundImage(Properties.Resources.oo14_2);
                SharedData.image2 = 1;
            }

            if (isButton3Clicked)
            {
                _form1.SetButton1BackgroundImage(Properties.Resources.oo15_2);
                SharedData.image2 = 2;
            }

            if(isButton8Clicked)
            {
                _form1.SetButton1BackgroundImage(Properties.Resources.oo16_2);
                SharedData.image2 = 3;
            }

            if (isButton9Clicked)
            {
                _form1.SetButton1BackgroundImage(Properties.Resources.oo17_2);
                SharedData.image2 = 4;
            }

            if (!buttonSequence.Contains(6))
            {
                buttonSequence.Add(6);
                CheckButtonSequence();
            }


            isButton6Clicked = true;
            _form1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)      // 얼음정수돌돌이 클릭
        {
            pictureBox1.Image = Properties.Resources.oo19_1;

            isButton3Clicked = true;
            isButton8Clicked = false;
            isButton9Clicked = false;
            isButton1Clicked = false;
        }

        private void button7_Click(object sender, EventArgs e)      // 펑펑효과 클릭
        {
            Form4 form4 = new Form4(_form1);
            form4.Show();
            Hide();
        }

        private void button9_MouseEnter(object sender, EventArgs e)     // 감시자 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.oo21;

            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)      // 모래몰이돌돌이 클릭
        {
            pictureBox1.Image = Properties.Resources.oo20_3;

            isButton8Clicked = true;
            isButton9Clicked = false;
            isButton1Clicked = false;
            isButton3Clicked = false;

            if (!buttonSequence.Contains(8))
            {
                buttonSequence.Add(8);
                CheckButtonSequence();
            }
        }

        private void button8_MouseEnter(object sender, EventArgs e)     // 모래몰이돌돌이 MouseEnter
        {
            pictureBox1.Image = Properties.Resources.oo20_3;
        }

        private void button9_Click(object sender, EventArgs e)      // 감시자 클릭
        {
            pictureBox1.Image = Properties.Resources.oo21;

            isButton9Clicked = true;
            isButton1Clicked = false;
            isButton3Clicked = false;
            isButton3Clicked = false;

            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            if (isButton1Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo18_2;
                button6.BackgroundImage = Properties.Resources.ll22_2;
            }
            if (isButton3Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo19_2;
                button6.BackgroundImage = Properties.Resources.ll22_2;
            }
            if (isButton8Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo20_2;
                button6.BackgroundImage = Properties.Resources.ll22_1;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            isButton11Clicked = true;
            buttonSequence.Add(11);

            if (isButton1Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo18_2;
                button11.BackgroundImage = Properties.Resources.oo23_2on2;

                if (button10.BackgroundImage != null || button12.BackgroundImage != null)
                {
                    button10.BackgroundImage = null; // button10의 배경 이미지를 제거
                    button12.BackgroundImage = null;
                }
            }
            if (isButton3Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo19_2;
                button11.BackgroundImage = Properties.Resources.oo23_2on2;

                if (button10.BackgroundImage != null || button12.BackgroundImage != null)
                {
                    button10.BackgroundImage = null; // button10의 배경 이미지를 제거
                    button12.BackgroundImage = null;
                }
            }
            if (isButton8Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo20_2;
                button11.BackgroundImage = Properties.Resources.oo23_2onon;

                if (button10.BackgroundImage != null || button12.BackgroundImage != null)
                {
                    button10.BackgroundImage = null; // button10의 배경 이미지를 제거
                    button12.BackgroundImage = null;
                }
            }
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            if (isButton1Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo18_1;
                button6.BackgroundImage = Properties.Resources.ll22_1;
            }
            if (isButton3Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo19_1;
                button6.BackgroundImage = Properties.Resources.ll22_1;
            }
            if (isButton8Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo20_1;
                button6.BackgroundImage = Properties.Resources.ll22_1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            isButton10Clicked = true;
            buttonSequence.Add(10);

            if (isButton1Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo18_1;
                button10.BackgroundImage = Properties.Resources.oo23_1on;

                if (button11.BackgroundImage != null || button12.BackgroundImage != null)
                {
                    button11.BackgroundImage = null;
                    button12.BackgroundImage = null;
                }
            }
            if (isButton3Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo19_1;
                button10.BackgroundImage = Properties.Resources.oo23_1on;

                if (button11.BackgroundImage != null || button12.BackgroundImage != null)
                {
                    button11.BackgroundImage = null;
                    button12.BackgroundImage = null;
                }

            }
            if (isButton8Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo20_1;
                button10.BackgroundImage = Properties.Resources.oo23_1on;

                if (button11.BackgroundImage != null || button12.BackgroundImage != null)
                {
                    button11.BackgroundImage = null;
                    button12.BackgroundImage = null;
                }
            }
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            if (isButton1Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo18_3;
                button6.BackgroundImage = Properties.Resources.ll22_3;
            }
            if (isButton3Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo19_3;
                button6.BackgroundImage = Properties.Resources.ll22_3;
            }
            if (isButton8Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo20_3;
                button6.BackgroundImage = Properties.Resources.ll22_1;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            isButton12Clicked = true;
            buttonSequence.Add(12);

            if (isButton1Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo18_3;
                button12.BackgroundImage = Properties.Resources.oo23_3on;

                if (button10.BackgroundImage != null || button11.BackgroundImage != null)
                {
                    button10.BackgroundImage = null; // button10의 배경 이미지를 제거
                    button11.BackgroundImage = null;
                }
                button6.Enabled = false;
            }

            if (isButton3Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo19_3;
                button12.BackgroundImage = Properties.Resources.oo23_3on;

                if (button10.BackgroundImage != null || button11.BackgroundImage != null)
                {
                    button10.BackgroundImage = null; // button10의 배경 이미지를 제거
                    button11.BackgroundImage = null;
                }
                button6.Enabled = false;
            }
            if (isButton8Clicked)
            {
                pictureBox1.Image = Properties.Resources.oo20_3;
                button12.BackgroundImage = Properties.Resources.oo23_3onon;

                if (button10.BackgroundImage != null || button11.BackgroundImage != null)
                {
                    button10.BackgroundImage = null; // button10의 배경 이미지를 제거
                    button11.BackgroundImage = null;
                }
            }
        }

        private void CheckButtonSequence()
        {
            if (buttonSequence.Count == 3)
            {
                // 버튼 8 -> 10 -> 6 순서일 때
                if (buttonSequence[0] == 8 && buttonSequence[1] == 10 && buttonSequence[2] == 6)
                {
                    _form1.ChangeButton1Background(1);

                    isButton8Clicked = false;
                    isButton10Clicked = false;
                    isButton6Clicked = false;
                }
                // 버튼 8 -> 11 -> 6 순서일 때
                if (buttonSequence[0] == 8 && buttonSequence[1] == 11 && buttonSequence[2] == 6)
                {
                    _form1.ChangeButton1Background(2);
                    isButton8Clicked = false;
                    isButton11Clicked = false;
                    isButton6Clicked = false;
                }
                // 버튼 8 -> 12 -> 6 순서일 때
                if (buttonSequence[0] == 8 && buttonSequence[1] == 12 && buttonSequence[2] == 6)
                {
                    _form1.ChangeButton1Background(3);
                    isButton8Clicked = false;
                    isButton12Clicked = false;
                    isButton6Clicked = false;
                }

                // 순서 초기화
                buttonSequence.Clear();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (SharedData.select1)  // Form1의 select 변수가 true이면
            {
                button1.BackgroundImage = Properties.Resources.oo14_1;  // 이미지2로 변경
            }
            else
            {
                button1.BackgroundImage = Properties.Resources.oo14_3;  // 기본 이미지1로 설정
            }

            if (SharedData.select2)  // Form1의 select 변수가 true이면
            {
                button3.BackgroundImage = Properties.Resources.oo15_1;  // 이미지2로 변경
            }
            else
            {
                button3.BackgroundImage = Properties.Resources.oo15_3;  // 기본 이미지1로 설정
            }

            if (SharedData.select3)  // Form1의 select 변수가 true이면
            {
                button8.BackgroundImage = Properties.Resources.oo16_1;  // 이미지2로 변경
            }
            else
            {
                button8.BackgroundImage = Properties.Resources.oo16_5;  // 기본 이미지1로 설정
            }

            if (SharedData.select4)  // Form1의 select 변수가 true이면
            {
                button9.BackgroundImage = Properties.Resources.oo17_1;  // 이미지2로 변경
            }
            else
            {
                button9.BackgroundImage = Properties.Resources.oo17_3;  // 기본 이미지1로 설정
            }
        }
    }
}
