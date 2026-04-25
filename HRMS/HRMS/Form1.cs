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

    public partial class login : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["HRMS"].ConnectionString;
         
        
     
        public login()
        {

            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection("Data Source=DESKTOP-G8PNI1F\\SQLEXPRESS;Initial Catalog=HRMS;Integrated Security=True");
            myconn.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (radioButton1.Checked == true)
            {
                SqlDataReader dr;
                string user = "select password, username from Login where type_ = 0 and username = '" + username + "' and password= '" + password+"'";
                SqlCommand comm1 = new SqlCommand(user, myconn);
                // string pass = "select password from Login where type_ = 0 and password = 123";
                // SqlCommand comm2 = new SqlCommand(pass, myconn);
                dr= comm1.ExecuteReader();
                string n="";string p = "";
                bool flag = false;
                while(dr.Read())
                {
                  
                    n=dr["username"].ToString();
                    p= dr["password"].ToString();
                }
                //MessageBox.Show(""+Rows);
                if (n!="" && p!="")
                {

                    MessageBox.Show("welcome admin !");
                    home adminlogin = new home(flag);
                    this.Hide();
                    home admin = new home(flag);
                    admin.Show();
                    
                    

                }
                else { MessageBox.Show("invalid username or password."); }
  
                myconn.Close();
            }
            if (radioButton2.Checked==true)
            {
                SqlDataReader dr;
                string user = "select password, username from Login where type_ = 1 and username = '" + username + "' and password= '" + password + "'";
                SqlCommand comm1 = new SqlCommand(user, myconn);
                // string pass = "select password from Login where type_ = 0 and password = 123";
                // SqlCommand comm2 = new SqlCommand(pass, myconn);
                dr = comm1.ExecuteReader();
                string n = ""; string p = "";
                bool flag = true;
                while (dr.Read())
                {

                    n = dr["username"].ToString();
                    p = dr["password"].ToString();
                }
                //MessageBox.Show(""+Rows);
                if (n != "" && p != "")
                {

                    MessageBox.Show("welcome user!");
                    home userlogin = new home(flag);
                    this.Hide();
                    home admin = new home(flag);
                    admin.Show();


                }
                else { MessageBox.Show("invalid username or password."); }
               

                myconn.Close();
            }



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    }

