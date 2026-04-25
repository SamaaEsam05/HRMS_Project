using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Home
{
    public partial class addsalary : Form
    {
        public SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        string sqlQuery;
        SqlDataAdapter sqlDA;
        DataTable sqlDT;




        public void loadRole()
        {  
            sqlQuery = "SELECT [ID],[Type_role] FROM [dbo].[Rolee]";
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);
            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox3.DataSource = sqlDT;
            comboBox3.DisplayMember = "Type_role";
            comboBox3.ValueMember = "ID";
           comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public addsalary()
        {
            InitializeComponent();
           
            loadRole();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addsalary_Load(object sender, EventArgs e)
        {
            
            

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Msalary ms = new Msalary();
            ms.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        { 
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //UPDATE [dbo].[Rolee] SET [base] = 2000 WHERE[ID] = 1
            string sql = "UPDATE [dbo].[Rolee] SET[base] = "+ richTextBox3.Text+ " WHERE [ID] = "+comboBox3.SelectedValue;
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            sqlconn.Open();
            cmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Save successfully");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
