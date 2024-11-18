using AxWMPLib;
using game00;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game00
{
    public partial class Start4 : Form
    {
        private string tempFilePath; // 임시 파일 경로를 저장할 필드
        private byte[] videoData; // 비디오 데이터
        private Timer stopTimer; // 비디오 정지를 위한 타이머
        private Start2 form2;
        private Start1 form1;
        private Start3 form3;
        private int a;
        private bool state = false;
        public Start4(Start1 form1, Start2 form2, Start3 form3)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            state = true;
            InitializeVideoPlayer(); // 비디오 초기화
            axWindowsMediaPlayer1.Visible = true; // 비디오 플레이어 보이기
            axWindowsMediaPlayer1.Ctlcontrols.play(); // 비디오 재생 시작 
            this.form1 = form1;
            this.form2 = form2;
            this.form3 = form3;
        }
        public Start4(int a)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            state = false;
            this.a = a;
            InitializeComponent();
            InitializeVideoPlayer(); // 비디오 초기화
            axWindowsMediaPlayer1.Visible = true; // 비디오 플레이어 보이기
            axWindowsMediaPlayer1.Ctlcontrols.play(); // 비디오 재생 시작 
        }

        private void InitializeVideoPlayer()
        {
            // 리소스에서 동영상을 읽어옴
            videoData = Properties.Resources._157__포로_뭉치___꼬마_전설이_쇼케이스___전략적_팀_전투___YouTube___Chrome_2024_10_20_18_10_52; // 리소스 이름
            tempFilePath = Path.GetTempFileName() + ".mp4"; // 임시 파일 경로

            // 임시 파일에 저장
            File.WriteAllBytes(tempFilePath, videoData);

            axWindowsMediaPlayer1.URL = tempFilePath; // 임시 파일 경로 설정
            axWindowsMediaPlayer1.uiMode = "none"; // UI 요소 숨기기

            // 타이머 초기화
            stopTimer = new Timer();
            stopTimer.Interval = 23000; // 23초
            stopTimer.Tick += timer1_Tick;
            stopTimer.Start(); // 비디오 시작 시 타이머 시작
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(int newState)
        {
            // 재생 상태가 3 (Playing)일 때
            if (newState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                // 타이머가 이미 시작된 상태면 아무것도 하지 않음
            }
            else
            {
                // 비디오가 멈추면 타이머 정지
                stopTimer.Stop();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 비디오 정지
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop(); // 정지
                axWindowsMediaPlayer1.URL = ""; // URL 초기화
                File.Delete(tempFilePath); // 임시 파일 삭제
                stopTimer.Stop(); // 타이머 정지
                axWindowsMediaPlayer1.Visible = false; //비디어 플레이어 안보이기

                if (state)
                {
                    string life1 = form1.lb_life.Text;
                    string life2 = form2.lb_life.Text;
                    if (int.Parse(life1) > 0)
                    {
                        label1.Text = "플레이어1";
                    }
                    else if (int.Parse(life2) > 0)
                    {
                        label1.Text = "플레이어2";
                    }
                    else
                    {
                        label2.Text = "무승부";
                    }
                }
                else if (!state)
                {
                    if (a == 1)
                    {
                        label1.Text = "플레이어2";
                    }
                    else
                    {
                        label1.Text = "플레이어1";
                    }
                }


            }
        }

        private void Start4_Load(object sender, EventArgs e)
        {

        }
    }
}
