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
    public partial class home : Form
    {
        
        public home()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendnce att = new attendnce();
            att.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            managevaca manVaca = new managevaca();
            manVaca.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AddNewAccount create = new AddNewAccount();
            create.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            deduction dedu = new deduction();
            dedu.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageRewards mreward = new manageRewards();
            mreward.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Msalary managesalary = new Msalary();
            managesalary.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageemp manageEmployee = new manageemp();           
            manageEmployee.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageLeave manlea = new ManageLeave();
            manlea.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewAccount create = new AddNewAccount();      
            create.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
    
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeYourPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            changepass pass = new changepass();
            
            pass.Show();
        }

        private void proToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendnce att = new attendnce();
            att.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageemp manageEmployee = new manageemp();
            manageEmployee.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendnce att = new attendnce();
            att.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            managevaca manVaca = new managevaca();
            manVaca.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageLeave manlea = new ManageLeave();
            manlea.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageRewards mreward = new manageRewards();
            mreward.Show();
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            deduction dedu = new deduction();
            dedu.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Msalary managesalary = new Msalary();
            managesalary.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewAccount create = new AddNewAccount();
            create.Show();
        }
    }
}
