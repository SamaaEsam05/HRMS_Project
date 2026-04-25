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
    public partial class AddNewAccount : Form
    {
        public AddNewAccount()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddNewAccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRMSDataSet3.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.hRMSDataSet3.Department);

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void comboBox1_DisplayMemberChanged(object sender, EventArgs e)
        {

        }
    }
}
