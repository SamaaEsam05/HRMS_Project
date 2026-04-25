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
    public partial class ManageLeave : Form
    {
        public int EmpID, DepID, id,indexrow;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataTable sqldt = new DataTable();
        SqlCommandBuilder scb = new SqlCommandBuilder();

        SqlDataAdapter sqlDA = new SqlDataAdapter();

        public ManageLeave()
        {
            InitializeComponent();
            string con2 = ConfigurationManager.ConnectionStrings["HRMSCon"].ConnectionString;
            SqlConnection con = new SqlConnection(con2);
            Loaddep();
            LoadEmp();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRMSDataSet2.Leave' table. You can move, or remove it, as needed.
            // this.leaveTableAdapter.Fill(this.hRMSDataSet2.Leave);
            // TODO: This line of code loads data into the 'hRMSDataSet1.Leave' table. You can move, or remove it, as needed.
            //this.leaveTableAdapter.Fill(this.hRMSDataSet1.Leave);


        }



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            addleav addlea = new addleav();
            addlea.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            comboBox3.DataSource = sqlDT;
            comboBox3.DisplayMember = "Type_lt";
            comboBox3.ValueMember = "ID";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadDataGrid()
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);

          //  bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            cmd = new SqlCommand("Select [ID], [frome] , [too] , [Date_leave] , [leavtype_id] from [dbo].[Leave]", con);

            sqlDA = new SqlDataAdapter(cmd);
            //     comboBox2.ValueMember = "Employe_id ";

            sqldt = new DataTable();
            sqlDA.Fill(sqldt);
            dataGridView1.DataSource = sqldt;
            loadType();
        }
        #region LoadType
        /*public void loadType()
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
        }*/
        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            cmd = new SqlCommand("Select ID, [frome] , [too] , [Date_leave] , [leavtype_id] from [dbo].[Leave] ", con);
          
            sqlDA = new SqlDataAdapter(cmd);
            //     comboBox2.ValueMember = "Employe_id ";

            sqldt = new DataTable();
            sqlDA.Fill(sqldt);
            dataGridView1.DataSource = sqldt;
            loadType();

        }
        public void EmpLoad1()
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            string SQLQuery = "SELECT [id] , [namee] from [dbo].[Department]";
            SqlCommand cmd = new SqlCommand(SQLQuery, con);
            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            DataTable sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            comboBox1.DataSource = sqlDT;
            comboBox1.DisplayMember = "[namee]";
            comboBox1.ValueMember = "[id]";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmp();

        }
        /*9   public void EmpLoad2()
           {
               if (con.State == ConnectionState.Closed)
               { con.Open(); }
               string SQLQuery = "SELECT [ID] , [employees_name] from [dbo].[Employee]";
               SqlCommand cmd = new SqlCommand(SQLQuery, con);
               SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
               DataTable sqlDT = new DataTable();
               sqlDA.Fill(sqlDT);
               comboBox2.DataSource = sqlDT;
               comboBox2.DisplayMember = "employees_name";
               comboBox2.ValueMember = "ID";
               comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
           }*/
        public void Loaddep()
        {


            //////////////////////
            //bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out DepID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id, namee from [dbo].[Department]", con);
            comboBox1.DataSource = dt;

            da.Fill(dt);

            comboBox1.DisplayMember = "namee";
            comboBox1.ValueMember = "id";
        }
        public void LoadEmp()
        {


            //////////////////////
            bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out DepID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, employees_name from [dbo].[Employee] where [department_id]=" + DepID, con);
            comboBox2.DataSource = dt;

            da.Fill(dt);

            comboBox2.DisplayMember = "employees_name";
            comboBox2.ValueMember = "ID";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out EmpID);
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Select * from [dbo].[Department] where id=" + EmpID, con);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            #region commm
            /*
            DataGridViewRow NewDataRow = dataGridView1.Rows[indexrow];
            NewDataRow.Cells[0].Value = textBox2.Text;
            NewDataRow.Cells[1].Value = dateTimePicker1.Text;
            NewDataRow.Cells[2].Value = dateTimePicker2.Text;
            NewDataRow.Cells[3].Value = dateTimePicker3.Text;
            NewDataRow.Cells[4].Value = comboBox3.Text;
            */
            #endregion




            ////  */
            //if (comboBox2.SelectedItem == null)
            //{ MessageBox.Show("select the Employee"); }
            //else
            //{
                string IDD = dateTimePicker1.Text;
                string gov = dateTimePicker3.Value.ToString("yyyy-MM-dd");
                string ss = comboBox3.SelectedValue.ToString();
                //MessageBox.Show(gov);
                int idd;
                string Timefrom, TimeTo;
                bool res = int.TryParse(comboBox3.SelectedValue.ToString(), out idd);
                Timefrom= dateTimePicker1.Text;
                TimeTo = dateTimePicker2.Text;
                string queryString = "UPDATE [dbo].[Leave] SET frome =" + "'" + Timefrom + "'" + " WHERE ID =" +Convert.ToInt32( textBox2.Text);
                string queryString1 = "UPDATE [dbo].[Leave] SET too =" + "'" + TimeTo + "'" + " WHERE ID =" + Convert.ToInt32(textBox2.Text);
                string queryString2 = "UPDATE [dbo].[Leave] SET [Date_leave]=" + "'" + gov + "'" + "WHERE ID =" + Convert.ToInt32(textBox2.Text);
                string queryString3 = "UPDATE [dbo].[Leave] SET [leavtype_id]=" + "'" + ss + "'" + "WHERE ID =" + Convert.ToInt32(textBox2.Text);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlCommand cmd1 = new SqlCommand(queryString1, con);
                SqlCommand cmd2 = new SqlCommand(queryString2, con);
                SqlCommand cmd3 = new SqlCommand(queryString3, con);
                double affectedRows = cmd.ExecuteNonQuery();
                double affectedRows1 = cmd1.ExecuteNonQuery();
                double affectedRows2 = cmd2.ExecuteNonQuery();
                double affectedRows3 = cmd3.ExecuteNonQuery();
                //if (affectedRows > 0 && affectedRows2 > 0 && affectedRows1>0)
                //{ MessageBox.Show("Edited Successfully !"); }
                //else
                //{
                //    MessageBox.Show("Failed");
                //}
                //dateTimePicker2.Text = "";
                //dateTimePicker2.Enabled = false;

                ////dateTimePicker1.Text = "";
                //dateTimePicker1.Enabled = false;
                con.Close();
            //}
        }
             private void btn_Edit_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dataGridView1.Rows[indexrow];
            textBox2.Text = row.Cells[0].Value.ToString();
            dateTimePicker1.Text = row.Cells[1].Value.ToString();
            dateTimePicker2.Text = row.Cells[2].Value.ToString();
            dateTimePicker3.Text = row.Cells[3].Value.ToString();
            //comboBox3.Text = row.Cells[4].Value.ToString();
            comboBox3.SelectedValue = row.Cells[4].Value;
            //if (comboBox2.SelectedItem == null)
            //{ MessageBox.Show("select the Employee"); }
            //else
            //{
            //    dateTimePicker1.Enabled = true;
            //    dateTimePicker2.Enabled = true;
               
            //    bool result = int.TryParse(comboBox2.SelectedValue.ToString(), out EmpID);
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter("Select ID,Date_leave from [dbo].[Leave] where ID=" + id, con);
            //    da.Fill(dt);
            //    int txt_ID = Convert.ToInt32(dateTimePicker2.Text.ToString());
            //    txt_ID=Convert.ToInt32( dt.Rows[0]["ID"].ToString());
            //    dateTimePicker1.Text = dt.Rows[0]["Date_leave"].ToString();
               #region comment
                 //comboBox3.Enabled = true;
                //textBox22.Enabled = true;
                //comboBox4.Enabled = true;
                //comboBox4.Text = dt.Rows[0]["social_status"].ToString();
                //textBox16.Text = dt.Rows[0]["phone_num"].ToString();
                //comboBox3.Text = dt.Rows[0]["governrate"].ToString();
#endregion
            }




            
        

        private void Delete_Click(object sender, EventArgs e)
        {
            /*
             
            if (EmpID != 0)
            {
                cmd = new SqlCommand("Delete  [dbo].[Leave] where iD =@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID",iD);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully");
                DisplayData();
                ClearData();
                //
            }


            else
            {
                MessageBox.Show("Select Row First");
            }
             */

            //try
            //{
                DataGridViewRow row = dataGridView1.Rows[indexrow];
                id = Convert.ToInt32(row.Cells[0].Value.ToString());

                //id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                MessageBox.Show(id + "");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand("Delete from [dbo].[Leave] where ID =" + id, con);
                cmd.ExecuteNonQuery();
                LoadDataGrid();
                MessageBox.Show("Deleted Successfully");
                LoadDataGrid();
                con.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("Select Row First");
            //}


}

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           indexrow = e.RowIndex;
        //    DataGridViewRow row = dataGridView1.Rows[indexrow];
        //    textBox2.Text = row.Cells[0].Value.ToString();
        //    dateTimePicker1.Text = row.Cells[1].Value.ToString();
        //    dateTimePicker2.Text = row.Cells[2].Value.ToString();
        //    dateTimePicker3.Text = row.Cells[3].Value.ToString();
        //    comboBox3.Text = row.Cells[4].Value.ToString();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_Edit_MouseClick(object sender, MouseEventArgs e)
        {
            //indexrow = e.RowIndex;
            //DataGridViewRow row = dataGridView1.Rows[indexrow];

            //textBox2.Text = row.Cells[0].Value.ToString();
            //dateTimePicker1.Text = row.Cells[1].Value.ToString();
            //dateTimePicker2.Text = row.Cells[2].Value.ToString();
            //dateTimePicker3.Text = row.Cells[3].Value.ToString();
            //comboBox3.Text = row.Cells[4].Value.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       


        }
    }

