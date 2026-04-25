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
namespace Home
{
    public partial class AddDeduct : Form
       {
        int id;
        public SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        public void loadDep()
        {
            string sqlquary = "SELECT [id] , [namee] FROM [dbo].[Department]";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlconn);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "namee";
            comboBox2.ValueMember = "id";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void loadEmp()
        {
            int depID;
            bool x = int.TryParse(comboBox2.SelectedValue.ToString(), out depID);
            string sqlquary = "SELECT [ID] , [employees_name] FROM [HRMS].[dbo].[Employee] where [department_id]='" + depID + "'";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlconn);

            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox1.DataSource = sqlDT;
            comboBox1.DisplayMember = "employees_name";
            comboBox1.ValueMember = "ID";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
     
        public AddDeduct()
        {
            InitializeComponent();
            loadDep();
            loadEmp();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            deduction managededuction = new deduction();
            managededuction.Show();
        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (sqlconn.State==ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            int dep;
            int employee;
            bool emp = int.TryParse(comboBox1.SelectedValue.ToString(),out employee);
            string reason = textBox2.Text;
            string date = dateTimePicker1.Value.ToString("yyy-MM-dd");
            string type = textBox1.Text;
            
            
            string sqlquery = "insert into [dbo].[Deductions] (ID,[Reason], [date_deduction],[type_deduction],[emp_id])values ('" + id + "', N'" + reason + "','" + date + "', N'" + type + "','" + employee + "')";
            SqlCommand sqlcom = new SqlCommand(sqlquery,sqlconn);
            sqlcom.ExecuteNonQuery();
            MessageBox.Show("Save Complete");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            deduction mdeduct = new deduction();
            mdeduct.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadEmp();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
