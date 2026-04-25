using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Home
{
    public partial class AttendREPORT : Form
    {
        public SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString);
        string sqlQuery;
        SqlDataAdapter sqlDA;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private Button button4;
        private ComboBox comboBox1;
        DataTable sqlDT;
        public void LoadDept()
        {
            sqlQuery = "SELECT Department.id,Department.namee FROM  Department";
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);

            comboBox1.DataSource = sqlDT;
            comboBox1.DisplayMember = "namee";
            comboBox1.ValueMember = "id";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public AttendREPORT()
        {
            InitializeComponent();
            LoadDept();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.OpenForms[0].Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Monthly_emp__attend monthly_Emp = new Monthly_emp__attend();
            monthly_Emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // SqlDataReader SqlDataReader;
            //SELECT Employee.employees_name,Attendance.Time_attend,Attendance.Time_Leave FROM[dbo].[Attendance] INNER JOIN[dbo].[Employee] ON Employee.ID = Attendance.EMP_ID WHERE Attendance.Date = '7-4-2022' AND Attendance.Department_ID = 3
            sqlQuery = "SELECT Employee.employees_name,Attendance.Time_attend,Attendance.Time_Leave FROM[dbo].[Attendance] INNER JOIN[dbo].[Employee] ON Employee.ID = Attendance.EMP_ID  WHERE Attendance.Date = " + "'" + dateTimePicker1.Text + "'" + "AND Attendance.Department_ID = " + comboBox1.SelectedValue;
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlconn);
            sqlconn.Close();
            sqlconn.Open();
            sqlDA = new SqlDataAdapter(sqlQuery, sqlconn);

            sqlDT = new DataTable();
            sqlDA.Fill(sqlDT);
            sqlconn.Close();
            dataGridView1.DataSource = sqlDT;

        }

        private void AttendREPORT_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 667);
            this.panel1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(229, 60);
            this.button3.TabIndex = 74;
            this.button3.Text = "Monthly employee attendance";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(229, 60);
            this.button2.TabIndex = 73;
            this.button2.Text = "Attendance of department";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 60);
            this.button1.TabIndex = 72;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Home.Properties.Resources.HRMS_L;
            this.pictureBox1.Location = new System.Drawing.Point(12, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(613, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(323, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(273, 29);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(409, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.Size = new System.Drawing.Size(693, 507);
            this.dataGridView1.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.Location = new System.Drawing.Point(1079, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 55);
            this.button4.TabIndex = 9;
            this.button4.Text = "Get Employees";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(709, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(307, 31);
            this.comboBox1.TabIndex = 8;
            // 
            // AttendREPORT
            // 
            this.ClientSize = new System.Drawing.Size(1278, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Name = "AttendREPORT";
            this.Load += new System.EventHandler(this.AttendREPORT_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AttendREPORT_Load_1(object sender, EventArgs e)
        {

        }
    }
}
