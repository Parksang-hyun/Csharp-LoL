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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace game00
{
    public partial class Purchase4 : Form
    {
        

        public Purchase4()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("정말 구매하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 예 버튼을 클릭했을 때 실행할 코드
                MessageBox.Show("구매 완료");
                SharedData.select4 = true;
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                SharedData.select4 = false;
            }
        }
    }
}
