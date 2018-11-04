using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class Form2 : Form
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["HFCDB"].ConnectionString.ToString();
        public Form2()
        {
            InitializeComponent();
        }
        public class Item
        {
            public int IDItem { get; set; }
            public string itemName { get; set; }
            public int itemPrice { get; set; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Item> menuList = new List<Item>();
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT IDItem, itemName, itemPrice FROM trItem;";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        menuList.Add(new Item() { IDItem = reader.GetInt32(0), itemName = reader.GetString(1), itemPrice = reader.GetInt32(2) });
                    }
                }
                command.Parameters.Clear();
                connection.Close();
            }

            int x = 12, y = 12, loop = 1;
            foreach (var i in menuList)
            {
                Button newBtn = new Button();
                newBtn.Width = 75;
                newBtn.Height = 61;
                newBtn.Visible = true;
                Point p = new Point(x, y);
                newBtn.Click += new EventHandler(Button_Click);
                newBtn.Text = i.itemName;
                newBtn.Location = p;

                this.Controls.Add(newBtn);
                if (loop % 3 == 0 && loop != 0)
                {
                    x = 12;
                    y += 65;
                }
                else
                {
                    x += 81;
                }
                loop++;
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String purchase = new string(new char[] { });
            int totalprice = Convert.ToInt32(label2.Text);
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT itemPrice FROM trItem WHERE itemName = @itemName;";
                command.Parameters.AddWithValue("@itemName", button.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        totalprice += reader.GetInt32(0);
                        purchase += button.Text;
                        purchase += " Rp ";
                        purchase += reader.GetInt32(0).ToString();
                        listBox1.Items.Add(purchase);
                    }
                }
                command.Parameters.Clear();
                connection.Close();
            }
            label2.Text = totalprice.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            listBox1.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string purchased = "Buy: ";
            foreach (var x in listBox1.Items)
            {
                purchased += x.ToString();
                purchased += "; ";
            }
            purchased += "Total = Rp ";
            purchased += label2.Text;

            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "INSERT INTO trTransactions VALUES (@transactionText, @transactionPrice, @IDUser);";
                command.Parameters.AddWithValue("@transactionText", purchased);
                command.Parameters.AddWithValue("@transactionPrice", label2.Text);
                command.Parameters.AddWithValue("@IDUser", LoginInfo.IDUser);
                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Clear();
                connection.Close();
            }

            MessageBox.Show("Order Succesfully Recorded! Total Price = Rp " + label2.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
