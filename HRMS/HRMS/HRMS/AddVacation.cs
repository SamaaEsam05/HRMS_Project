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
    public partial class addvaca : Form
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);

        public void LoudDept() 
        {
            string sqlquary = "SELECT  [id] , [namee] FROM [dbo].[Department]";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox1.DataSource = sqlDT;
            comboBox1.DisplayMember = "namee";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoudEmp()
        {
            int deptID;
            bool x = int.TryParse(comboBox1.SelectedValue.ToString(),out deptID);
            string sqlquary = "SELECT [ID],[employees_name] FROM [HRMS].[dbo].[Employee] where [department_id]='"+deptID+"' ";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);
         
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void Loudtype()
        {
            string sqlquary = "SELECT  [ID] , [Type_vt] FROM [dbo].[vacation_type]";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox3.DataSource = sqlDT;
            comboBox3.DisplayMember = "Type_vt";
            comboBox3.ValueMember = "ID";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public addvaca()
        {
            InitializeComponent();
            LoudDept();
            LoudEmp();
            Loudtype();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
       
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            managevaca mvaca = new managevaca();
            mvaca.Show();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            int dept;
            bool depart = int.TryParse(comboBox1.SelectedValue.ToString(), out dept);
            int Employee;
            bool emp = int.TryParse(comboBox2.SelectedValue.ToString(), out Employee);
            int type;
            bool re = int.TryParse(comboBox3.SelectedValue.ToString(), out type);
            int balance = Convert.ToInt32(textBox2.Text);
            int requird = Convert.ToInt32( textBox3.Text);
            string date_ = dateTimePicker1.Value.ToString("yyy-MM-dd");
            string date_to = dateTimePicker2.Value.ToString("yyyy-MM-dd");
           
            string sqlquery = "insert into  [dbo].[vacation] ([Date_from],[Date_to],[emp_id],[vac_id],[balance],[required_]) values('" + date_ + "','" + date_to + "','" + Employee + "','" + type + "','" + balance + "','" + requird +"')";
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcom.ExecuteNonQuery();
            if (balance <=requird)
            {
                MessageBox.Show("This Requird isn't avilable");
            }
            else
            {
                MessageBox.Show("Save Complete");
            }
        }                                                                       

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoudEmp();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Addvaca_Load(object sender, EventArgs e)
        {

        }
    }
}
