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

namespace HRMS
{
    public partial class manage_employee : Form
    {
        public SqlConnection sqlll = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        public int EmpID,DepID;
        public manage_employee()
        {
            InitializeComponent();
            LoadDep();
            LoadEmp();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            addEmployee add = new addEmployee();
            add.Show();

        }
        public void LoadDep()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id,namee from [dbo].[Department]", sqlll);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "namee";
            comboBox1.ValueMember = "id";
        }
        public void LoadEmp()
        {
            bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out DepID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, employees_name from [dbo].[Employee] where [department_id]="+DepID, sqlll);
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
        }
        private void manage_employee_Load(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmp();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            { MessageBox.Show("select the Employee"); }
            else
            {
                textBox16.Enabled = true;
                textBox6.Enabled = true;
                comboBox3.Enabled = true;
                textBox22.Enabled = true;
                comboBox4.Enabled = true;

                bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select [employees_name],addres,Email,social_status,phone_num,governrate from [dbo].[Employee] where ID=" + EmpID, sqlll);
                da.Fill(dt);

                textBox6.Text = dt.Rows[0]["addres"].ToString();
                textBox22.Text = dt.Rows[0]["Email"].ToString();
                comboBox4.Text = dt.Rows[0]["social_status"].ToString();
                textBox16.Text = dt.Rows[0]["phone_num"].ToString();
                comboBox3.Text = dt.Rows[0]["governrate"].ToString();

            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            { MessageBox.Show("select the Employee"); }
            else
            {
                string address = textBox6.Text;
                string gov = comboBox3.Text;
                string pn = textBox16.Text;
                string em = textBox22.Text;
                string ss = comboBox4.Text;
                int id;
                bool res = int.TryParse(comboBox2.SelectedValue.ToString(), out id);
                string queryString = "UPDATE Employee SET addres='" + address + "' WHERE ID = '" + id + "'";
                string queryString2 = "UPDATE Employee SET Email='" + em + "' WHERE ID = '" + id + "'";
                string queryString3 = "UPDATE Employee SET social_status='" + ss + "' WHERE ID = '" + id + "'";
                string queryString4 = "UPDATE Employee SET governrate='" + gov + "' WHERE ID = '" + id + "'";
                string queryString5 = "UPDATE Employee SET phone_num='" + pn + "' WHERE ID = '" + id + "'";
                if (sqlll.State == ConnectionState.Closed)
                {
                    sqlll.Open();
                }
                SqlCommand cmd = new SqlCommand(queryString, sqlll);
                SqlCommand cmd2 = new SqlCommand(queryString2, sqlll);
                SqlCommand cmd3 = new SqlCommand(queryString3, sqlll);
                SqlCommand cmd4 = new SqlCommand(queryString4, sqlll);
                SqlCommand cmd5 = new SqlCommand(queryString5, sqlll);

                int affectedRows = cmd.ExecuteNonQuery();
                int affectedRows2 = cmd2.ExecuteNonQuery();
                int affectedRows3 = cmd3.ExecuteNonQuery();
                int affectedRows4 = cmd4.ExecuteNonQuery();
                int affectedRows5 = cmd5.ExecuteNonQuery();
                if (affectedRows > 0 && affectedRows2>0 && affectedRows3 > 0 && affectedRows4 > 0 && affectedRows5 > 0)
                { MessageBox.Show("Edited Successfully !"); }
                else
                {
                    MessageBox.Show("Failed");
                }
                textBox16.Text = "";
                textBox16.Enabled = false;

                textBox22.Text = "";
                textBox22.Enabled = false;

                textBox6.Text = "";
                textBox6.Enabled = false;

                comboBox3.Enabled = false;
                comboBox4.Enabled = false;

            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string address = textBox6.Text;
            int id;
            bool res = int.TryParse(comboBox2.SelectedValue.ToString(), out id);           
            string queryString = "delete from Employee WHERE ID = '" + id + "'";
            if (sqlll.State == ConnectionState.Closed)
            {
                sqlll.Open();
            }
            SqlCommand cmd = new SqlCommand(queryString, sqlll);
       
            int affectedRows = cmd.ExecuteNonQuery();
            if (affectedRows > 0  )
            { MessageBox.Show("Deleted Successfully !"); }           
            else
            {
                MessageBox.Show("Failed");
            }
            LoadEmp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            addEmployee dd = new addEmployee();
            dd.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select employees_name ,employee_age,addres,qualification,religion,gender  from [dbo].[Employee] where ID=" + EmpID, sqlll);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
