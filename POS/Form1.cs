using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS
{
    public partial class Form1 : Form
    {
        public string connString = "Data Source=IT-AM\\SQLEXPRESS;Initial Catalog=HFC_DB;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT IDUser FROM msUser WHERE Username = @username AND Password = @password";
                command.Parameters.AddWithValue("@username", textBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        LoginInfo.IDUser = reader.GetInt32(0);
                    }
                    connection.Close();
                    Form5 dashboard = new Form5();
                    dashboard.Show();
                    this.Hide();
                    dashboard.FormClosing += Dashboard_Closing;
                }
                else
                {
                    connection.Close();
                }
            }
        }
        private void Dashboard_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

    }
}
