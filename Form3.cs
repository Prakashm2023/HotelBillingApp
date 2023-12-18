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

namespace WindowsFormsApp11
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = HotelDB; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tblBilling(BillNo,Food,Price,Quantity,Amount) values(" + textBox1.Text + ",'" + comboBox1.Text + "'," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ")", con);

            con.Open();
            int s = cmd.ExecuteNonQuery();
            if (s > 0)
            {
                MessageBox.Show("Record inserted");
            }
            else
            {
                MessageBox.Show("Record Not Inserted");
            }
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Tea");
            comboBox1.Items.Add("Idly");
            comboBox1.Items.Add("Dosa");
            comboBox1.Items.Add("Poori");
            comboBox1.Items.Add("Biriyani");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           SqlCommand cmd = new SqlCommand("select * from tblBilling", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tea")
            {
                textBox2.Text = "10";
            }

            if (comboBox1.SelectedItem.ToString() == "Idly")
            {
                textBox2.Text = "15";
            }

            if (comboBox1.SelectedItem.ToString() == "Dosa")
            {
                textBox2.Text = "20";
            }

            if (comboBox1.SelectedItem.ToString() == "Poori")
            {
                textBox2.Text = "25";
            }

            if (comboBox1.SelectedItem.ToString() == "Biriyani")
            {
                textBox2.Text = "30";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text.Length > 0)
            {
                textBox4.Text = (Convert.ToInt16(textBox2.Text) * Convert.ToInt16(textBox3.Text)).ToString();
            }
        }
    }
}
