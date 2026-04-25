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
    public partial class addleav : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        public addleav()
        {
            #region comment
            //     InitializeComponent();
            //     string con = ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString;
            //     SqlConnection conn = new SqlConnection(con);
            //     string SQLQuery = "SELECT [ID] , [frome] , [too] , [Date_leave] , [Employe_id] , [leavtype_id] from [dbo].[Leave]";
            //     conn.Open();
            //     DataTable sqlDT = new DataTable();
            //     SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery,conn);
            //     sqlDA.Fill(sqlDT);
            ////     addleav.DataSource = sqlDT;
            //     conn.Close();
            #endregion
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm tt";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm tt";
            dateTimePicker2.ShowUpDown = true;
            string con2 = ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString;
            SqlConnection con = new SqlConnection(con2);
            //string SQLQuery = "SELECT [ID] , [frome] , [too] , [Date_leave] , [Employe_id] , [leavtype_id] from [dbo].[Leave]";
            //con.Open();
            //DataTable sqlDT = new DataTable();
            //SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, con);
            //sqlDA.Fill(sqlDT);
            EmpLoad();
            loadType();
            //     addleav.DataSource = sqlDT;
            //con.Close();
        }

        private void P8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            ManageLeave Mleave = new ManageLeave();
            Mleave.Show();


        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageLeave mleave = new ManageLeave();
            mleave.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            string query = "INSERT INTO Leave(frome , too , Date_leave , Employe_id , leavtype_id)values(@frome,@too,@Date_leave,@Employe_id,@leavtype_id)";
            int Emp, Type;
            bool res = Int32.TryParse(EMP_COMBOBOX.SelectedValue.ToString(), out Emp);
            bool res2 = Int32.TryParse(comboBox2.SelectedValue.ToString(), out Type);
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Employe_id", Emp);
            cmd.Parameters.AddWithValue("@leavtype_id", Type);
            cmd.Parameters.AddWithValue("@frome", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@too", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@Date_leave", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Save Complete");
        }

        private void EMP_COMBOBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpLoad();
        }
        public void EmpLoad()
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            string SQLQuery = "SELECT [ID] , [employees_name] from [dbo].[Employee]";
            SqlCommand cmd = new SqlCommand(SQLQuery, con);
            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            EMP_COMBOBOX.DataSource = sqlDT;
            EMP_COMBOBOX.DisplayMember = "employees_name";
            EMP_COMBOBOX.ValueMember = "ID";
            EMP_COMBOBOX.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadType();
        }
        public void loadType()
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            string SQLQuery = "SELECT [ID] , [Type_lt] from [dbo].[Leave_type]";
            SqlCommand cmd = new SqlCommand(SQLQuery, con);
            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox2.DataSource = sqlDT;
            comboBox2.DisplayMember = "Type_lt";
            comboBox2.ValueMember = "ID";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
