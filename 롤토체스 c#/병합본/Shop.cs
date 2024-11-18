using game00;
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
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Purchase1 ph1 = new Purchase1();
            ph1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Loby1 lb1 = new Loby1();
            lb1.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Loby2 lb2 = new Loby2();
            lb2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Purchase2 ph2 = new Purchase2();
            ph2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Purchase3 ph3 = new Purchase3();
            ph3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Purchase4 ph4 = new Purchase4();
            ph4.Show();
        }
    }
}
