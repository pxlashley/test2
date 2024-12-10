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
using System.Diagnostics.Eventing.Reader;

namespace test2
{
    public partial class Login : Form

    {
        SqlConnection conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\ashley.durgapersad\\source\repos\\test2\\Database1.mdf;Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from users where username=@username and password =@password", conn);
            cmd.Parameters.AddWithValue("@username", txtuser.Text);
            cmd.Parameters.AddWithValue("@password", txtpass.Text);

            conn.Open();

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                MessageBox.Show("Login Successful");
                Hide();//this form
                Form1 form1 = new Form1();
                form1.Show();
               
            }
            else
            {
                MessageBox.Show("Login Failure, Try Again");
            }
            conn.Close();
        }
    }
}

