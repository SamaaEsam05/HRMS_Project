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
    public partial class managevaca : Form
    { 
        public int indexrow;
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString);
        public int EmpID,id;
        public string dat;

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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

        }
        public void LoudVacation()
        {
            string sqlquary = "SELECT ID ,Type_vt FROM vacation_type";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox3.DataSource = sqlDT;
            comboBox3.DisplayMember = "Type_vt";
            comboBox3.ValueMember = "ID";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoudEmp()
        {
            int deptID;
            bool x = int.TryParse(comboBox1.SelectedValue.ToString(), out deptID);
            string sqlquary = "SELECT [ID],[employees_name] FROM [HRMS].[dbo].[Employee] where [department_id]='" + deptID + "' ";
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlquary, sqlcon);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadDataGrid()
        {
            bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out EmpID);
            SqlCommand cmd = new SqlCommand("Select Date_from,emp_id,balance,required_  from  [dbo].[vacation]", sqlcon);
            SqlDataAdapter  sqlDA = new SqlDataAdapter(cmd);
            DataTable sqldt = new DataTable();
            sqlDA.Fill(sqldt);
            dataGridView1.DataSource = sqldt;
            comboBox1.DisplayMember = "employees_name";
            comboBox1.ValueMember = "ID";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public managevaca()
        {
            InitializeComponent();
            LoudDept();
            LoudEmp();
            LoudVacation();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            addvaca addva = new addvaca();
            addva.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoudEmp();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            dat=dateTimePicker1.Value.ToString();
            MessageBox.Show(dat);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter ("Select ID,Date_from,emp_id,balance,required_  from  [dbo].[vacation]  where emp_id=" + EmpID+ " AND Date_from="+"'" +dat +"'", sqlcon);
            da.Fill(dt);
         
            dataGridView1.DataSource = dt;
        }
        public void LoadDARAGRID()
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            dat = dateTimePicker1.Value.ToString();
            MessageBox.Show(dat);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,Date_from,emp_id,balance,required_  from  [dbo].[vacation]  where emp_id=" + EmpID + " AND Date_from=" + "'" + dat + "'", sqlcon);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string IDD = dateTimePicker1.Text;
            string Timefrom;
            int VcType;
            bool result = int.TryParse(comboBox3.SelectedValue.ToString(), out VcType);
            Timefrom = dateTimePicker2.Text;
            string query = "update  [dbo].[vacation] set Date_from =" + "'" + Timefrom +("dd-MM-yyyy")+"'"+ "where ID="+VcType;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
        }

        private void Managevaca_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            //try
            //{
                DataGridViewRow row = dataGridView1.Rows[indexrow];
                id = Convert.ToInt32(row.Cells[0].Value.ToString());
  
            SqlCommand cmd = new SqlCommand("Delete from [dbo].[vacation] where ID =" + id, sqlcon);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Deleted Successfully");
                LoadDARAGRID();
            //}
            //catch
            //{
            //    MessageBox.Show("Select row first");
            //}
            sqlcon.Close();

        }

    }
}
