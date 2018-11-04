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
    public partial class Form6 : Form
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["HFCDB"].ConnectionString.ToString();
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "INSERT INTO trItem (itemName, itemPrice, IDCategory) VALUES (@itemName, @itemPrice, @IDCategory);";
                command.Parameters.AddWithValue("@itemName", textBox1.Text);
                command.Parameters.AddWithValue("@itemPrice", textBox2.Text);
                command.Parameters.AddWithValue("@IDCategory", comboBox1.SelectedValue);
                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
                connection.Close();
            }
            MessageBox.Show("Item successfully added!");
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT IDCategory, categoryName FROM trItemCategory";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        items.Add(reader.GetInt32(0).ToString(), reader.GetString(1).ToString());
                    }
                }
                command.Parameters.Clear();
                connection.Close();
            }
            comboBox1.DataSource = new BindingSource(items, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 addCategory = new Form9();
            addCategory.Show();
            this.Hide();
            addCategory.FormClosing += AddCategory_Closing;
        }
        private void AddCategory_Closing(object sender, FormClosingEventArgs e)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT IDCategory, categoryName FROM trItemCategory";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        items.Add(reader.GetInt32(0).ToString(), reader.GetString(1).ToString());
                    }
                }
                command.Parameters.Clear();
                connection.Close();
            }
            comboBox1.DataSource = new BindingSource(items, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            this.Show();
        }
    }
}
