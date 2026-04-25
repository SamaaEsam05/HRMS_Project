using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace HRMS
{
    public partial class attendnce : Form
    {
        public SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        string sqlQuery;
        SqlDataAdapter sqlDA;
        DataTable sqlDT;

        public void LoadDept()
        {
            sqlQuery = "SELECT Department.id,Department.namee FROM  Department";
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);

            com_dept.DataSource = sqlDT;
            com_dept.DisplayMember = "namee";
            com_dept.ValueMember = "id";
            com_dept.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public void LoadEmp()
        {
            int dept;
            bool ss = int.TryParse(com_dept.SelectedValue.ToString(), out dept);
            sqlQuery = "SELECT [ID],[employees_name]FROM [dbo].[Employee] where [department_id]=" + dept ;
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);

            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public attendnce()
        {
            InitializeComponent();

            LoadDept();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void P7_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlDataReader SqlDataReader;
             //SELECT[Time_attend],[Time_Leave] FROM Attendance where[Date] = '2022-04-07' and[EMP_ID] = 1
            sqlQuery = "SELECT [Time_attend],[Time_Leave] FROM Attendance where [Date]= "+"'"+dateTimePicker1.Text+"'"+ "AND [EMP_ID] ="+comboBox2.SelectedValue;
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlconn);
         
            sqlconn.Open();
            SqlDataReader = cmd.ExecuteReader();
            while(SqlDataReader.Read())
            {
                TimeSpan span = (TimeSpan)SqlDataReader["Time_attend"];
                dateTimePicker2.Text=span.ToString();
                dateTimePicker2.Enabled = false;
               
                TimeSpan span2 = (TimeSpan)SqlDataReader["Time_Leave"];
                dateTimePicker3.Text = span2.ToString();
                dateTimePicker3.Enabled = false;
            }
            sqlconn.Close();
       
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        private void button4_Click(object sender, EventArgs e)
        {
            
            importFromEXCEL import = new importFromEXCEL();
            import.Show();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void com_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = true;
            dateTimePicker3.Enabled = true;
        
         

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("select the employ");
            }
            string attend_time = dateTimePicker2.Text;
            string leave_time = dateTimePicker3.Text;
            int id;
            bool res = int.TryParse(comboBox2.SelectedValue.ToString(), out id);
            string queryString1 = "UPDATE Attendance SET [Time_attend] ="+"'" + dateTimePicker2.Text +"'" + " WHERE [EMP_ID] = " + comboBox2.SelectedValue;
            string queryString2 = "UPDATE Attendance SET [Time_Leave] =" + "'"  + dateTimePicker3.Text + "'" + " WHERE [EMP_ID] = " + comboBox2.SelectedValue ;
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            SqlCommand cmd1 = new SqlCommand(queryString1, sqlconn);
            SqlCommand cmd2 = new SqlCommand(queryString2, sqlconn);
   
            int affectedRow1 = cmd1.ExecuteNonQuery();

            int affectedRow2 = cmd2.ExecuteNonQuery();
  
           cmd1.ExecuteNonQuery();
           cmd2.ExecuteNonQuery();


            if (affectedRow1 >0 && affectedRow2 >0)
            {
                MessageBox.Show("Edited Successfully ");
            }
            else { MessageBox.Show("Failed ! "); }
        }
    }






    
}
