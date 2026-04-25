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
    
    public partial class manageRewards : Form
    {
        int indexrow;
        public SqlConnection mainConn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        string sqlquary;
        SqlDataAdapter dataAdap;
        DataTable dataTable;
        public int EmpID, id;
        SqlCommand cmd;
        SqlCommandBuilder sqlcombuilder;
        DataTable newDT;
        SqlTransaction transaction;
        int ID = 0;
        public manageRewards()
        {
            InitializeComponent();
            LoadDepartment();
            Loadeward();
            DisplayData();
            ClearData();


            //string mainconn = ConfigurationManager.ConnectionStrings["myconniction"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);

        }
        public void Delete(int id, int idemp)
        {
            sqlquary = "delete from Department where id='" + id + "'";
            sqlquary = "delete from rewards where emp_id='" + idemp + "'";
            cmd = new SqlCommand(sqlquary, mainConn);
            mainConn.Open();
            cmd.ExecuteNonQuery();
            mainConn.Close();
        }

        private void DisplayData()
        {
            mainConn.Open();
            DataTable dt = new DataTable();
            dataAdap = new SqlDataAdapter("select * from rewards", mainConn);
            dataAdap.Fill(dt);
            dataGridView1.DataSource = dt;
            mainConn.Close();
         


        }
        ////Clear Data  
        private void ClearData()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            id = 0;
        }
        public void Loadeward()
        {
            //string sqlquaryy = "select * from rewards";
            //mainConn.Open();
            //DataTable dtt = new DataTable();
            //SqlDataAdapter sdrr = new SqlDataAdapter(sqlquaryy, mainConn);
            //sdrr.Fill(dtt);
            //dataGridView1.DataSource = dtt;
            //mainConn.Close();
        }
        private void manageRewards_Load(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t.Columns.Add("ID", typeof(int));
            t.Columns.Add("Date_rewords", typeof(DateTime));
            t.Columns.Add("reason", typeof(string));
            t.Columns.Add("emp_id", typeof(int));
            t.Columns.Add("rewards_type", typeof(string));
            t.Columns.Add("amount", typeof(int));

            dataGridView1.DataSource = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            addrewa addreward = new addrewa();
            addreward.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            addrewa addreward = new addrewa();
            addreward.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
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

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "employees_name";
            comboBox1.ValueMember = "ID";
        }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainConn.State == ConnectionState.Closed)
            {
                mainConn.Open();
            }
            //cells[0]
            int EID;
            bool rel = int.TryParse(comboBox1.SelectedValue.ToString(), out EID);
            string query = "select* from rewards where emp_id =" + EID;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, mainConn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mainConn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)

        {

            
              if (comboBox2.SelectedItem == null)
              { MessageBox.Show("select the rewards"); }
              else

              {
                  dateTimePicker1.Enabled = true;
                  textBox3.Enabled = true;
                  textBox4.Enabled = true;
                  textBox5.Enabled = true;

              
              
               

                //bool result = int.TryParse(comboBox1.SelectedValue.ToString(), out EmpID);
                //  DataTable dt = new DataTable();
                //  SqlDataAdapter da = new SqlDataAdapter("Select  [Date_rewords],reason,rewards_type,amount from [dbo].[rewards] where rewards.ID=" + EmpID, mainConn);
                //  da.Fill(dt);

                DataGridViewRow row = dataGridView1.Rows[indexrow];
                id = Convert.ToInt32(row.Cells[0].Value.ToString());
                dateTimePicker1.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
            
            //try
            //{
            //    sqlcombuilder = new SqlCommandBuilder(dataAdap);
            //    newDT = dataTable.GetChanges();
            //    int ri = dataGridView1.CurrentRow.Index;
            //    if (newDT != null)
            //    {
            //        dataAdap.Update(newDT);
            //    }
            //    MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //string IDD = dateTimePicker1.Text;
            //string Timefrom;
            //int VcType;
            //bool result = int.TryParse(comboBox3.SelectedValue.ToString(), out VcType);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*if (id != 0)
            {
                cmd = new SqlCommand("delete rewards where ID=@ID", mainConn);
                mainConn.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully!");
                mainConn.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
            */
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                string dep = comboBox1.SelectedValue.ToString();
                int id = int.Parse(dep);
                string emp = comboBox2.SelectedValue.ToString();
                int idemp = int.Parse(emp);
                Delete(id, idemp);
                LoadDepartment();
                DisplayData();
                MessageBox.Show("deleted");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexrow = e.RowIndex;
            //MessageBox.Show(""+indexrow);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem == null)
            { MessageBox.Show("select the rewards"); }
            else
            {
                string date =( dateTimePicker1.Text);             
                string reason = textBox3.Text;
                string type = textBox4.Text;
                string Amount = textBox5.Text;
                int id;
                DataGridViewRow row = dataGridView1.Rows[indexrow];
                id = Convert.ToInt32(row.Cells[0].Value.ToString());
                //bool res = int.TryParse(comboBox1.SelectedValue.ToString(), out id);
                string queryString2 = "UPDATE rewards SET Date_rewords=" +"'"+ date + "'" + "WHERE ID =" + id;
                string queryString3 = "UPDATE rewards SET reason = '" + reason + "' WHERE ID =" + id;
                string queryString4 = "UPDATE rewards SET rewards_type=" + type + "WHERE ID = " + id;
                string queryString5 = "UPDATE rewards SET amount=" + Amount + "WHERE ID = " + id;
                if (mainConn.State == ConnectionState.Closed)
                {
                    mainConn.Open();
                }
                SqlCommand cmd1 = new SqlCommand(queryString2, mainConn);
                SqlCommand cmd3 = new SqlCommand(queryString3, mainConn);
                SqlCommand cmd4 = new SqlCommand(queryString4, mainConn);
                SqlCommand cmd5 = new SqlCommand(queryString5, mainConn);

                double affectedRows = cmd1.ExecuteNonQuery();
                double affectedRows1 = cmd3.ExecuteNonQuery();
                double affectedRows2 = cmd4.ExecuteNonQuery();
               double  affectedRows3 = cmd5.ExecuteNonQuery();
                mainConn.Close();
                MessageBox.Show("Save Complete");
                //if (affectedRows > 0 && affectedRows2 > 0 && affectedRows3 > 0 && affectedRows4 > 0 )
                //{ MessageBox.Show("Edited Successfully !"); }
                //else
                //{
                //    MessageBox.Show("Failed");
                //}
                //textBox1.Text = "";
                //textBox1.Enabled = false;

                //textBox2.Text = "";
                //textBox2.Enabled = false;

                //textBox3.Text = "";
                //textBox3.Enabled = false;
                //textBox4.Text = "";
                //textBox4.Enabled = false;

                /*
                try
                {
                    mainConn.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO rewards (ID,Date_rewords,reason,emp_id,rewards_type,amount)VALUES(@ID,@Date_rewords,@reason,@emp_id,@rewards_type,@amount)", mainConn))
                        {
                            cmd.Parameters.AddWithValue("@ID", row.Cells["ID"].Value);
                            cmd.Parameters.AddWithValue("@Date_rewords", row.Cells["Date_rewords"].Value);
                            cmd.Parameters.AddWithValue("@reason", row.Cells["reason"].Value);
                            cmd.Parameters.AddWithValue("@emp_id", row.Cells["emp_id"].Value);
                            cmd.Parameters.AddWithValue("@rewards_type", row.Cells["rewards_type"].Value);
                            cmd.Parameters.AddWithValue("@amount", row.Cells["amount"].Value);
                             transaction = mainConn.BeginTransaction();
                            cmd.Transaction = transaction;
                            cmd.ExecuteNonQuery();
                        }
                    }
                  cmd.Transaction.Commit();
                    mainConn.Close();
                    MessageBox.Show("Successfully Saved!");
                }
                catch (Exception ex)
                {
                    ////transaction.Rollback();
                    mainConn.Close();
                    MessageBox.Show(ex.Message);
                }
                */


            }
        }
    }
}
