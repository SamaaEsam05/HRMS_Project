using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMS
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AttendREPORT attendREPORT = new AttendREPORT();
            attendREPORT.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AttendREPORT attendREPORT = new AttendREPORT();
            attendREPORT.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }
    }
}
