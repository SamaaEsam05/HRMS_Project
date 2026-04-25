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
using System.IO;



namespace HRMS
{
    public partial class addrewa : Form
    {
        public SqlConnection mainConn=new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        string sqlquary;
        SqlDataAdapter dataAdap;
        DataTable dataTable;
        public void LoadDepartment()
        {
            mainConn.Open();
            sqlquary = "select id,namee from [dbo].Department";
            dataAdap = new SqlDataAdapter(sqlquary, mainConn);
            dataTable = new DataTable();
            dataAdap.Fill(dataTable);

            comboBox2.DataSource = dataTable;
            comboBox2.DisplayMember = "namee";
            comboBox2.ValueMember = "id";
            mainConn.Close();

        }
        public addrewa()
        {
            InitializeComponent();
            LoadDepartment();
            LoadEmp();
            LoadRewardType();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            manageRewards maddreward = new manageRewards();
            maddreward.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadEmp();


        }
        public void LoadEmp()
        {
            string sqlqua = "Select Employee.ID,Employee.employees_name From Employee";
            dataAdap = new SqlDataAdapter(sqlqua, mainConn);
            dataTable = new DataTable();
            dataAdap.Fill(dataTable);

            comboBox3.DataSource = dataTable;
            comboBox3.DisplayMember = "employees_name";
            comboBox3.ValueMember = "ID";
        }
        public void LoadRewardType()
        {
            string sqlqua = "Select rewards_type_.reward_id,rewards_type_.reward_type From rewards_type_";
            dataAdap = new SqlDataAdapter(sqlqua, mainConn);
            dataTable = new DataTable();
            dataAdap.Fill(dataTable);

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "reward_type";
            comboBox1.ValueMember = "reward_id";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (mainConn.State == ConnectionState.Closed)
            {
                mainConn.Open();
            }
            string s = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //StreamWriter sw = new StreamWriter("Data.txt", true);
            //int x = 5;
            //int id = ++x;
            string reason = textBox5.Text;
            int EMPID = 0;int retype = 0;
            bool result=int.TryParse(comboBox3.SelectedValue.ToString(),out EMPID);
            bool result2 = int.TryParse(comboBox1.SelectedValue.ToString(), out retype);
            int amount =Convert.ToInt32( textBox4.Text);
            //string strData = comboBox2.Text + ";"
            //    + comboBox3.Text + ";" + textBox5.Text + ";"
            //    + dateTimePicker1.Text + ";"
            //    + comboBox1.Text + ";" + textBox4.Text;
            //sw.WriteLine(strData);
            //sw.Close();
            string sqlquery = "insert into  [dbo].[rewards] ([Date_rewords],[reason],[emp_id],[rewards_type],[amount]) values('" + s +"',N'"+reason+"','"+EMPID+"','"+retype+"','"+amount+"')";
            SqlCommand sqlcom = new SqlCommand(sqlquery, mainConn);
            sqlcom.ExecuteNonQuery();
            MessageBox.Show("تمت الإضافة بنجاح");
            //foreach (Control c in this.Control                         \\s)
            //{
            //    if (c is TextBox)
            //        c.Text = "";

            //    //}
            //    //comboBox2.Focus();


         }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Remove(comboBox2.Text);
            comboBox1.Items.Remove(comboBox1.Text);
            //textBox4.Items.Remove(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
