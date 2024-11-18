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
    public partial class Loby1 : Form
    {
        private string tempFilePath1; // 임시 파일 경로를 저장할 필드
        private byte[] videoData; // 비디오 데이터
        private bool state = true;
        private int count = 0;
        public Loby1()
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

        private void InitializeVideoPlayer()
        {
            // 리소스에서 동영상을 읽어옴
            videoData = Properties.Resources.로비화면; // 리소스 이름
            tempFilePath1 = Path.GetTempFileName() + ".mp4"; // 임시 파일 경로

            // 임시 파일에 저장
            File.WriteAllBytes(tempFilePath1, videoData);

            axWindowsMediaPlayer1.URL = tempFilePath1; // 임시 파일 경로 설정
            axWindowsMediaPlayer1.settings.setMode("loop", true); // 무한 재생 설정
            axWindowsMediaPlayer1.uiMode = "none"; // UI 요소 숨기기
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loby2 loby2 = new Loby2();
            loby2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("이 작업을 진행하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 예 버튼을 클릭했을 때 실행할 코드
                Close();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shop shop1 = new Shop();
            shop1.Show();
            this.Close();
        }
    }
}
