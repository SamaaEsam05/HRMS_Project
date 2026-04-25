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


namespace HRMS
{
    public partial class AttendREPORT : Form
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

            comboBox1.DataSource = sqlDT;
            comboBox1.DisplayMember = "namee";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public AttendREPORT()
        {
            InitializeComponent();
            LoadDept();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Monthly_emp__attend monthly_Emp = new Monthly_emp__attend();
            monthly_Emp.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           // SqlDataReader SqlDataReader;
            //SELECT Employee.employees_name,Attendance.Time_attend,Attendance.Time_Leave FROM[dbo].[Attendance] INNER JOIN[dbo].[Employee] ON Employee.ID = Attendance.EMP_ID WHERE Attendance.Date = '7-4-2022' AND Attendance.Department_ID = 3
            sqlQuery = "SELECT Employee.employees_name,Attendance.Time_attend,Attendance.Time_Leave FROM[dbo].[Attendance] INNER JOIN[dbo].[Employee] ON Employee.ID = Attendance.EMP_ID  WHERE Attendance.Date = " + "'" + dateTimePicker1.Text + "'" + "AND Attendance.Department_ID = " + comboBox1.SelectedValue;
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlconn);
            sqlconn.Close();
            sqlconn.Open();
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            sqlconn.Close();
            dataGridView1.DataSource = sqlDT;

        }

        private void AttendREPORT_Load(object sender, EventArgs e)
        {

        }
    }
}
