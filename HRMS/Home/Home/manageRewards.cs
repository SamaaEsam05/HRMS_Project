using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class manageRewards : Form
    {
        public manageRewards()
        {
            InitializeComponent();
        }

        private void manageRewards_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            addrewa addreward = new addrewa();
            addreward.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            addrewa addreward = new addrewa();
            addreward.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }
    }
}
