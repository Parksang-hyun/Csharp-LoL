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
    public partial class Registration : Form
    {
        public event EventHandler<UserEventArgs> UserRegistered;
        public Registration()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public class UserEventArgs : EventArgs
        {
            public string UserId { get; }
            public string Password { get; }
            public string Nickname { get; }
            public string Birthdate { get; }

            public UserEventArgs(string userId, string password, string nickname, string birthdate)
            {
                UserId = userId;
                Password = password;
                Nickname = nickname;
                Birthdate = birthdate;
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string id = textBox_Id.Text;
            string password = textBox_Pass.Text;
            string nickname = textBox_Nickname.Text;
            string birthdate = dateTimePicker1.Text;

            Form1 form1 = new Form1();

            form1.LabelText = textBox_Nickname.Text;

            

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(nickname) || string.IsNullOrWhiteSpace(birthdate))
            {
                MessageBox.Show("모든 필드를 입력하세요.");
                return;
            }

            if (!radioButton_Agree.Checked)
            {
                MessageBox.Show("개인정보 동의가 필요합니다.");
                return;
            }

            // ID 중복 체크는 Form1에서 처리해야 함.
            // UserRegistered 이벤트 발생
            UserRegistered?.Invoke(this, new UserEventArgs(id, password, nickname, birthdate));

            MessageBox.Show("회원가입이 완료되었습니다.");
            this.Close();
        }
    }
}
