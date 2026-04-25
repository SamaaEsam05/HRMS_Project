using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Home
{
    public partial class deduction : Form
    {       
        public SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        
        SqlCommand cmd = new SqlCommand();
        DataTable sqldt = new DataTable();
        SqlCommandBuilder scb = new SqlCommandBuilder();

        SqlDataAdapter sqlDA = new SqlDataAdapter();

        public int EmpID, DepID, id, indexrow;
        public deduction()
        {
            InitializeComponent();
            LoadDep();
            loadEmp();

        }
        public void LoadDep()
        {
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT id,namee FROM [dbo].[Department]", sqlconn);
            DA.Fill(DT);
            comboBox1.DataSource = DT;
            comboBox1.DisplayMember = "namee";
            comboBox1.ValueMember = "id";
        }
        public void loadEmp()
        {

            bool x = int.TryParse(comboBox1.SelectedValue.ToString(), out DepID);
            DataTable DT = new DataTable();

            SqlDataAdapter DA = new SqlDataAdapter("Select ID, employees_name from [dbo].[Employee] where [department_id]=" + DepID, sqlconn);
            DA.Fill(DT);
            comboBox2.DataSource = DT;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
        }

        private void P18_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            AddDeduct adddeduc = new AddDeduct();
            adddeduc.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
            AddDeduct adddeduct = new AddDeduct();
            adddeduct.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out EmpID);
            //DataTable DT = new DataTable();
            //SqlDataAdapter DA = new SqlDataAdapter("Select * from  where ID=" + EmpID, sqlconn);
            //DA.Fill(DT);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           loadEmp();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("Select * from  Deductions where emp_id=" + EmpID, sqlconn);
            DA.Fill(DT);
            dataGridView1.DataSource = DT;

            //string id = dataGridView1.Rows[dataGridView1.CurrentRow.Selected].ToString();
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //sqlconn.Open();
            indexrow = e.RowIndex;
            //SqlCommand com = new SqlCommand("Delete from Deductions where ID ="+id,sqlconn);
            //com.ExecuteNonQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
               textBox1.Enabled =true;
                textBox2.Enabled = true;

              bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select [Reason],[type_deduction] from [dbo].[Deductions] where ID=" + EmpID,sqlconn);
                da.Fill(dt);
            DataGridViewRow row = dataGridView1.Rows[id];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string reason = textBox1.Text;
            string type = textBox2.Text;
            int idd;
           // string ID = int.TryParse(comboBox2.SelectedValue.ToString(),out idd);
            
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            id = Convert.ToInt32(row.Cells[0].Value.ToString());
         
            string queryString = "UPDATE [dbo].[Deductions] SET [Reason]=" + reason +"Where ID ="+id;
            string queryString2 = "UPDATE [dbo].[Deductions] SET [type_deduction] =" + type + "Where ID =" + id; ;
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            SqlCommand cmd1 = new SqlCommand(queryString2, sqlconn);
            double affectedRows = cmd.ExecuteNonQuery();
            double affectedRows1 = cmd1.ExecuteNonQuery();
            sqlconn.Close();
            //DataGridViewRow row = dataGridView1.Rows[id];
            //string iddd = row.Cells[0].Value.ToString();
            //MessageBox.Show(iddd);
            //string queryString = "UPDATE [dbo].[Deductions] SET [Reason]=" + reason + " WHERE ID = " + id;
            //string queryString2 = "UPDATE [dbo].[Deductions] SET [type_deduction] ='" + type + "WHERE ID = " + id ;

            //SqlCommand sqlcom = new SqlCommand(queryString, sqlconn);
            //SqlCommand cmd = new SqlCommand(queryString, sqlconn);
            //SqlCommand cmd2 = new SqlCommand(queryString2, sqlconn);

            //int affectedRows = cmd.ExecuteNonQuery();
            //int affectedRows2 = cmd2.ExecuteNonQuery();
            //if (affectedRows > 0 && affectedRows2 > 0 )
            //{ MessageBox.Show("Edited Successfully !"); }
            //else
            //{
            //    MessageBox.Show("Failed");
            //}

            MessageBox.Show("Save Complete");
        }
        public void LoadDataGrid()
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);

            //  bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            cmd = new SqlCommand("Select * from  Deductions from [dbo].[Deductions] ", sqlconn);

            sqlDA = new SqlDataAdapter(cmd);
            //     comboBox2.ValueMember = "Employe_id ";

            sqldt = new DataTable();
            sqlDA.Fill(sqldt);
            dataGridView1.DataSource = sqldt;
            
        }

        private void Delete(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[indexrow];
            id = Convert.ToInt32(row.Cells[0].Value.ToString());
            MessageBox.Show(id + "");

            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            cmd = new SqlCommand("Delete from [dbo].[Deductions] where ID =" + id, sqlconn);
            cmd.ExecuteNonQuery();
            LoadDataGrid();
            MessageBox.Show("Deleted Successfully");
            LoadDataGrid();
            sqlconn.Close();

            //try
            //{
            //    sqlconn.Open();
            //    //int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
            //    SqlCommand com = new SqlCommand("Delete from Deductions where ID =" + id, sqlconn);
            //    com.ExecuteNonQuery();
            //    MessageBox.Show("Deleted Successfully");
            //}
            //catch
            //{
            //    MessageBox.Show("Select row first");
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
