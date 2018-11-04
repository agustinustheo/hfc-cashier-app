using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Form7 : Form
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["HFCDB"].ConnectionString.ToString();
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT b.firstName, b.lastName, a.IDUser, a.UserRole FROM msUser a JOIN trProfile b ON a.IDUser = b.IDUser WHERE a.IDUser = @IDUser;";
                command.Parameters.AddWithValue("@IDUser", LoginInfo.IDUser);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        textBox2.Text = reader.GetString(0).ToString() + reader.GetString(1).ToString();
                        textBox3.Text = reader.GetInt32(2).ToString();
                        if (reader.GetInt32(3) == 1)
                        {
                            textBox4.Text = "Admin";
                        }
                        else
                        {
                            textBox4.Text = "User";
                        }
                        textBox6.Text = LoginInfo.CheckInTime;
                    }
                }
            }
            textBox9.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
