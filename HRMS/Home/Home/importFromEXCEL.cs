using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using ExcelDataReader;

namespace Home
{
    public partial class importFromEXCEL : Form
    {
        
       private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public importFromEXCEL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            #region sss
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5]
            {
        //new DataColumn("ID", typeof(int)),
        new DataColumn("EMP_ID", typeof(int)),
        new DataColumn("Department_ID", typeof(int)),
        new DataColumn("Date", typeof(string)),
        new DataColumn("Time_attend", typeof(string)),
        new DataColumn("Time_Leave", typeof(string))
    });
            int count = dataGridView1.Rows.Count - 1;
            MessageBox.Show("" + count);


                foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id;
                bool result =Int32.TryParse(row.Cells[0].Value.ToString(), out id);
                 if (count != 0 && result == true)
                {
                   

                    int EMP_ID = Convert.ToInt32(row.Cells[0].Value);
                    int Department_ID = Convert.ToInt32(row.Cells[1].Value);
                    string Date = row.Cells[2].Value.ToString();
                    string Time_attend = row.Cells[3].Value.ToString();
                    string Time_Leave = row.Cells[4].Value.ToString();
                    dt.Rows.Add(EMP_ID, Department_ID, Date, Time_attend, Time_Leave);
                    count--;

                }
                
                else
                {
                    break;
                }
            }
            for (int i = 1; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "")
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                }
            }
            if (dt.Rows.Count > 0)
            {
                string str = ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        sqlBulkCopy.DestinationTableName = "[dbo].[Attendance]";
                        //sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                        sqlBulkCopy.ColumnMappings.Add("EMP_ID", "EMP_ID");
                        sqlBulkCopy.ColumnMappings.Add("Department_ID", "Department_ID");
                        sqlBulkCopy.ColumnMappings.Add("Date", "Date");
                        sqlBulkCopy.ColumnMappings.Add("Time_attend", "Time_attend");
                        sqlBulkCopy.ColumnMappings.Add("Time_Leave", "Time_Leave");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }
            #endregion
        }

        private void comSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
           // DataTable dt = tableCollection[comSheet.SelectedItem.ToString()];
           // dataGridView1.DataSource = dt;



        }
       // DataTableCollection tableCollection;
       
       

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            
            #region MyRegion
            //using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "" })
            //{
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        txtFilename.Text = openFileDialog.FileName;
            //        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
            //        {
            //            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            //            {
            //                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
            //                { ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true } });
            //                tableCollection = result.Tables;
            //                comSheet.Items.Clear();
            //                foreach (DataTable table in tableCollection)
            //                    comSheet.Items.Add(table.TableName);//add sheet to combo box 
            //            }
            //        }
            //    }

            //}
            #endregion
        }
        #region MyRegion
        //private void ofdSelect_FileOk(object sender, CancelEventArgs e)
        //{

        //    string filePath = openFileDialog1.FileName;
        //    string extension = Path.GetExtension(filePath);
        //    string conString = "";
        //    string sheetName = "Sheet1";
        //    switch (extension)
        //    {
        //        case ".xls":
        //            conString = string.Format(Excel03ConString, filePath, "YES");
        //            break;
        //        case ".xlsx":
        //            conString = string.Format(Excel07ConString, filePath, "YES");
        //            break;
        //    }
        //    using (OleDbConnection con = new OleDbConnection(conString))
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand())
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //            sheetName = dt.Rows[0]["Table_Name"].ToString();
        //            con.Close();
        //        }
        //    }
        //    using (OleDbConnection con = new OleDbConnection(conString))
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand())
        //        {
        //            OleDbDataAdapter oda = new OleDbDataAdapter();
        //            cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            oda.SelectCommand = cmd;
        //            DataTable dt = new DataTable();
        //            oda.Fill(dt);
        //            con.Close();
        //            dataGridView1.DataSource = dt;
        //        }
        //    }

        //}
        #endregion

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            string conString = "";
            string sheetName = "Sheet1";
            switch (extension)
            {
                case ".xls":
                    conString = string.Format(Excel03ConString, filePath, "YES");
                    break;
                case ".xlsx":
                    conString = string.Format(Excel07ConString, filePath, "YES");
                    break;
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dt.Rows[0]["Table_Name"].ToString();
                    con.Close();
                }
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    oda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    con.Close();
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void importFromEXCEL_Load(object sender, EventArgs e)
        {

        }
    }
}
