using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace HRMS
{
    public partial class REPORT_EMP : Form
    {
        public SqlConnection mainConn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        string sqlquary;
        SqlDataAdapter dataAdap;
        DataTable dataTable;
        public int EmpID, id;
        //public int emp_id;
        public REPORT_EMP()
        {
            InitializeComponent();
            LoadDepartment();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainConn.State == ConnectionState.Closed)
            {
                mainConn.Open();
            }
            int EID;
            //int eID;
            bool rel =int.TryParse(comboBox1.SelectedValue.ToString(), out EID);
            string query = " select Date_rewords,reason,rewards_type,amount,degree,Typee,Specialization,Graduation_year,desegnation,date_of_join,social_status,qualification,employees_name,governrate ,D_Reason,date_deduction,type_deduction from rewards, Employee, Deductions where rewards.emp_id = Employee.ID and Deductions.emp_id =Employee.ID  and Employee.ID ="+ EID;
            //string queryf = "select* from rewards where emp_id =" + EID;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query,  mainConn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mainConn.Close();
        }

        public void LoadEmp()
        {
            string sqlqua = "Select Employee.ID,Employee.employees_name From Employee";
            dataAdap = new SqlDataAdapter(sqlqua, mainConn);
            dataTable = new DataTable();
            dataAdap.Fill(dataTable);

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "employees_name";
            comboBox1.ValueMember = "ID";
        }
        public void LoadDepartment()
        {
            mainConn.Open();
            sqlquary = "select id,namee from [dbo].Department";
            dataAdap = new SqlDataAdapter(sqlquary, mainConn);
            dataTable = new DataTable();
            dataAdap.Fill(dataTable);

            comboBox3.DataSource = dataTable;
            comboBox3.DisplayMember = "namee";
            comboBox3.ValueMember = "id";
            mainConn.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadEmp();

        }


    }
}
