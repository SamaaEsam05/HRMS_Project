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
    public partial class Monthly_emp__attend : Form
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
        public void LoadEmp()
        {
            int dept;
            bool ss = int.TryParse(comboBox1.SelectedValue.ToString(), out dept);
            sqlQuery = "SELECT [ID] ,[employees_name] FROM [dbo].[Employee] where [department_id]=" + dept ;
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);

            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public Monthly_emp__attend()
        {
            InitializeComponent();
            LoadDept();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AttendREPORT attendREPORT = new AttendREPORT();
            attendREPORT.Show();
        }

        private void Monthly_emp__attend_Load(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlQuery = "SELECT  [dbo].[Employee].employees_name,[dbo].[Attendance].Time_attend,[dbo].[Attendance].Time_Leave  FROM[HRMS].[dbo].[Attendance] inner join[dbo].[Employee] on[dbo].[Employee].ID =[dbo].[Attendance].EMP_ID  WHERE   [dbo].[Attendance].[Date] between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'  " + "AND Attendance.Department_ID = " + comboBox1.SelectedValue + "AND [dbo].[Employee].ID = " + comboBox2.SelectedValue;
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlconn);
            sqlconn.Close();
            sqlconn.Open();
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable("HRMS");
            sqlDA.Fill(sqlDT);
            sqlconn.Close();
            dataGridView1.DataSource = sqlDT;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmp();
        }
    }
}
