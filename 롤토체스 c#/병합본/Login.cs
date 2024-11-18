using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using AxWMPLib; // 추가된 네임스페이스

namespace game00
{
    public partial class Login : Form
    {
        private Dictionary<string, (string Password, string Nickname, string Birthdate)> users = new Dictionary<string, (string, string, string)>();
        private string tempFilePath; // 임시 파일 경로를 저장할 필드
        private byte[] videoData; // 비디오 데이터
        private bool state = true;
        private int count = 0;
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (state)
            {
                InitializeVideoPlayer(); // 비디오 초기화
                axWindowsMediaPlayer1.Focus();
                // Windows Media Player를 맨 뒤로 보내기
                this.Controls.SetChildIndex(axWindowsMediaPlayer1, 0);
                axWindowsMediaPlayer1.Visible = true; // 비디오 플레이어 보이기
                axWindowsMediaPlayer1.Ctlcontrols.play(); // 비디오 재생 시작    
                state = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Registration registrationForm = new Registration();
            registrationForm.UserRegistered += (s, args) =>
            {
                // UserRegistered 이벤트를 통해 사용자 정보를 추가
                users.Add(args.UserId, (args.Password, args.Nickname, args.Birthdate));
            };
            registrationForm.Show();
        }

        private void InitializeVideoPlayer()
        {
            // 리소스에서 동영상을 읽어옴
            videoData = Properties.Resources.bandicam_2024_10_16_16_51_38_134; // 리소스 이름
            tempFilePath = Path.GetTempFileName() + ".mp4"; // 임시 파일 경로

            // 임시 파일에 저장
            File.WriteAllBytes(tempFilePath, videoData);

            axWindowsMediaPlayer1.URL = tempFilePath; // 임시 파일 경로 설정
            axWindowsMediaPlayer1.settings.setMode("loop", true); // 무한 재생 설정
            axWindowsMediaPlayer1.uiMode = "none"; // UI 요소 숨기기
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("정말로 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // 애플리케이션 종료
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox_Id.Text;
            string password = textBox_Pass.Text;

            if (count < 5)
            {
                if (users.ContainsKey(id) && users[id].Password == password)
                {
                    MessageBox.Show("로그인 되었습니다.");

                    Loby1 lb1 = new Loby1();
                    lb1.Show();
                    this.Hide();
                }
                else if (users.ContainsKey(id) && users[id].Password != password)
                {
                    count++;
                    MessageBox.Show($"비밀번호를 확인해주세요\n최대 로그인 횟수는 5회입니다\n로그인 시도횟수: {count}");
                    textBox_Id.Text = "";
                    textBox_Pass.Text = "";
                }
                else
                {
                    count++;
                    MessageBox.Show($"아이디를 확인해주세요\n최대 로그인 횟수는 5회입니다\n로그인 시도횟수: {count}");
                    textBox_Id.Text = "";
                    textBox_Pass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("5회 모두 틀리셨습니다.");
                Close();
            }
        }

        private void button2_MouseEnter_1(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.loginbtn1;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.loginbtn;
        }
    }
}
