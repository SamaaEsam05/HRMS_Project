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
namespace HRMS
{
    public partial class REPORT_vecation : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString);
        public int EmpID, id;
        public void LoudDept()
        {
            string sqlquary = "SELECT  [id] , [namee] FROM [dbo].[Department]";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox3.DataSource = sqlDT;
            comboBox3.DisplayMember = "namee";
            comboBox3.ValueMember = "id";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public void LoudEmp()
        {
            int deptID;
            bool x = int.TryParse(comboBox3.SelectedValue.ToString(), out deptID);
            string sqlquary = "SELECT [ID],[employees_name] FROM [HRMS].[dbo].[Employee] where [department_id]='" + deptID + "' ";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);

            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public REPORT_vecation()
        {
            InitializeComponent();
            LoudDept();
            LoudEmp();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Date_from,Type_vt from vacation,vacation_type where vacation_type.ID = vacation.vac_id and emp_id="+EmpID,sqlcon);
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
        }

        private void REPORT_vecation_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoudEmp();
        }
    }
}
