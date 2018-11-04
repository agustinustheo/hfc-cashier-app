using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS
{
    public partial class Form3 : Form
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["HFCDB"].ConnectionString.ToString();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void tbox10_Click(object sender, EventArgs e)
        {
            if(tbox8.Text == tbox3.Text)
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "INSERT INTO msUser (Username, Password, UserRole) VALUES (@Username, @Password, @UserRole); INSERT INTO trProfile (firstName, lastName, phoneNumber, IDUser) VALUES (@firstName, @lastName, @phoneNumber, (SELECT TOP 1 IDUser FROM msUser ORDER BY IDUser DESC));";
                    command.Parameters.AddWithValue("@Username", tbox7.Text);
                    command.Parameters.AddWithValue("@Password", tbox8.Text);
                    command.Parameters.AddWithValue("@UserRole", 2);
                    command.Parameters.AddWithValue("@firstName", tbox6.Text);
                    command.Parameters.AddWithValue("@lastName", tbox4.Text);
                    command.Parameters.AddWithValue("@phoneNumber", tbox2.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    connection.Close();
                }
                MessageBox.Show("Registred New User!");
            }
            else
            {
                MessageBox.Show("Password is not the same!");
            }

        }
    }
}
