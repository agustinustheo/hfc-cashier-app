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
    public partial class Form9 : Form
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["HFCDB"].ConnectionString.ToString();
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string categoryName = "";
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT categoryName FROM trItemCategory;";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categoryName = reader.GetString(0);
                        Currcats.Items.Add(categoryName);
                    }
                }
                connection.Close();
            }
        }

        private void addcatbutton_Click(object sender, EventArgs e)
        {
            Currcats.Items.Clear();
            string categoryName = "";
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "INSERT INTO trItemCategory VALUES (@categoryName);";
                command.Parameters.AddWithValue("@categoryName", addcat.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categoryName = reader.GetString(0);
                        Currcats.Items.Add(categoryName);
                    }
                }
                connection.Close();

                connection.Open();
                command.CommandText = "SELECT categoryName FROM trItemCategory;";
                reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categoryName = reader.GetString(0);
                        Currcats.Items.Add(categoryName);
                    }
                }
                connection.Close();
            }
        }

        private void delbutton_Click(object sender, EventArgs e)
        {
            Currcats.Items.Clear();
            string categoryName = "";
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "DELETE FROM trItemCategory WHERE categoryName = @categoryName;";
                command.Parameters.AddWithValue("@categoryName", Updatebox.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categoryName = reader.GetString(0);
                        Currcats.Items.Add(categoryName);
                    }
                }
                connection.Close();

                connection.Open();
                command.CommandText = "SELECT categoryName FROM trItemCategory;";
                reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categoryName = reader.GetString(0);
                        Currcats.Items.Add(categoryName);
                    }
                }
                connection.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
