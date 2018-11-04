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
    public partial class Form8 : Form
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["HFCDB"].ConnectionString.ToString();
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == textBox7.Text)
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    connection.Open();
                    command.CommandText = "SELECT IDUser FROM msUser WHERE Password = @Password";
                    command.Parameters.AddWithValue("@Password", textBox5.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows == true)
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        connection.Open();
                        command.CommandText = "UPDATE trProfile SET firstName = @firstName, lastName = @lastName, phoneNumber = @phoneNumber WHERE IDUser = @IDUser;";
                        command.Parameters.AddWithValue("@firstName", textBox1.Text);
                        command.Parameters.AddWithValue("@lastName", textBox2.Text);
                        command.Parameters.AddWithValue("@phoneNumber", textBox3.Text);
                        command.Parameters.AddWithValue("@IDUser", LoginInfo.IDUser);
                        reader = command.ExecuteReader();
                        command.Parameters.Clear();
                        connection.Close();
                        MessageBox.Show("Successfully updated profile!");
                    }
                    else
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        MessageBox.Show("Password is invalid!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Password is not the same!");
            }
            textBox5.Text = "";
            textBox7.Text = "";
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT a.Username, b.firstName, b.lastName, b.phoneNumber FROM msUser a JOIN trProfile b ON a.IDUser = b.IDUser WHERE a.IDUser = @IDUser;";
                command.Parameters.AddWithValue("@IDUser", LoginInfo.IDUser);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        label4.Text = "Hello, " + reader.GetString(0).ToString();
                        textBox1.Text = reader.GetString(1).ToString();
                        textBox2.Text = reader.GetString(2).ToString();
                        textBox3.Text = reader.GetString(3).ToString();
                    }
                }
                command.Parameters.Clear();
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
