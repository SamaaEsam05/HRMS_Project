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
    public partial class addEmployee : Form
    {
        public SqlConnection sqlll = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);

        public addEmployee()
        {
            InitializeComponent();
            LoadDep();
            LoadRole();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        public void LoadRole()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,Type_role from [dbo].[Rolee]", sqlll);
            da.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Type_role";
            comboBox3.ValueMember = "ID";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            manage_employee showManage = new manage_employee();
            showManage.Show();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox18.Text) && !String.IsNullOrEmpty(textBox4.Text)&&!String.IsNullOrEmpty(textBox20.Text) && !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(textBox21.Text) && !String.IsNullOrEmpty(textBox22.Text) && !String.IsNullOrEmpty(textBox16.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox17.Text) && !String.IsNullOrEmpty(textBox10.Text) && !String.IsNullOrEmpty(textBox12.Text) && !String.IsNullOrEmpty(textBox15.Text) && !String.IsNullOrEmpty(textBox7.Text) && !String.IsNullOrEmpty(textBox8.Text) && !String.IsNullOrEmpty(textBox9.Text)  )
            {
                if (sqlll.State != ConnectionState.Open)
                {
                    sqlll.Open();
                }
                int DepID = 0; int roleid; float degree;
                bool res = float.TryParse(textBox7.Text, out degree);
                bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out DepID);
                bool result2 = int.TryParse(comboBox3.SelectedValue.ToString(), out roleid);
                string query = "INSERT INTO [dbo].[Employee](department_id,gender,Birth_day,addres,Email,degree,Typee,Specialization,Graduation_year,role_id,desegnation,date_of_join,social_status,qualification,phone_num,id_number,employees_name,governrate,employee_age,religion) values(@department_id,@gender,@Birth_day,@addres,@Email,@degree,@Typee,@Specialization,@Graduation_year,@role_id,@desegnation,@date_of_join,@social_status,@qualification,@phone_num,@id_number,@employees_name,@governrate,@employee_age,@religion)";
                SqlCommand cmd = new SqlCommand(query, sqlll);
                

                //cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text));
                //cmd.Parameters.AddWithValue("@manger_id", Convert.ToInt32(textBox2.Text));
                cmd.Parameters.AddWithValue("@department_id", DepID);
                cmd.Parameters.AddWithValue("@gender", textBox4.Text);
                cmd.Parameters.AddWithValue("@Birth_day", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@addres", textBox6.Text);
                cmd.Parameters.AddWithValue("@religion", textBox21.Text);
                cmd.Parameters.AddWithValue("@Email", textBox22.Text);
                cmd.Parameters.AddWithValue("@degree", degree);
                cmd.Parameters.AddWithValue("@Typee", textBox8.Text);
                cmd.Parameters.AddWithValue("@Specialization", textBox9.Text);
                cmd.Parameters.AddWithValue("@Graduation_year", Convert.ToInt32(textBox10.Text));
                cmd.Parameters.AddWithValue("@role_id", roleid);
                cmd.Parameters.AddWithValue("@desegnation", textBox12.Text);

                cmd.Parameters.AddWithValue("@date_of_join", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@social_status", comboBox4.Text);
                cmd.Parameters.AddWithValue("@qualification", textBox15.Text);
                cmd.Parameters.AddWithValue("@phone_num", Convert.ToInt32(textBox16.Text));
                cmd.Parameters.AddWithValue("@id_number", Convert.ToInt32(textBox17.Text));
                cmd.Parameters.AddWithValue("@employees_name", textBox18.Text);

                cmd.Parameters.AddWithValue("@governrate", comboBox2.Text);
                cmd.Parameters.AddWithValue("@employee_age", Convert.ToInt32(textBox20.Text));
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully!");
                sqlll.Close();
            }
            else
            {
                MessageBox.Show("Complete the information !");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&&(e.KeyChar!='.'))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //emplty all cells
            textBox3.Clear(); textBox4.Clear(); textBox4.Clear();
            textBox6.Clear(); textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear();
            textBox15.Clear(); textBox12.Clear(); textBox16.Clear(); textBox17.Clear(); textBox18.Clear();
            textBox20.Clear(); textBox21.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
