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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("M");
            comboBox1.Items.Add("MA");
            comboBox1.Items.Add("MAN");
            comboBox1.Items.Add("MAEN");
        }

        string Ftype;

        SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HotelDB; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            // Submit - Insert

            SqlCommand cmd = new SqlCommand("insert into tblFood(Fname,Ftype,Fprice,Favailable) values('" + textBox1.Text + "','" + Ftype + "'," + textBox2.Text + ",'" + comboBox1.SelectedItem.ToString() + "')",con);

            con.Open();
            int s = cmd.ExecuteNonQuery();
            if (s > 0)
            {
                MessageBox.Show("Food Item Inserted");
            }
            else
            {
                MessageBox.Show("Food Item Not Inserted");
            }
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Ftype = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Ftype = radioButton2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // delete

            SqlCommand cmd = new SqlCommand("delete from tblFood where Fname = '" + textBox1.Text + "'", con);

            con.Open();
            int s = cmd.ExecuteNonQuery();
            if (s > 0)
            {
                MessageBox.Show("Food Item Deleted");
            }
            else
            {
                MessageBox.Show("Food Item Not Deleted");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Load

            SqlCommand cmd = new SqlCommand("select * from tblFood where Fname = '" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    string Ftype = dr["Ftype"].ToString();

                    if(Ftype == "VE")
                    {
                        radioButton1.Checked = true;
                    }
                    else if(Ftype == "NV")
                    {
                        radioButton2.Checked = true;
                    }

                    textBox2.Text = dr["Fprice"].ToString();
                    comboBox1.Text = dr["Favailable"].ToString();
                }
            }
            dr.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // update

            SqlCommand cmd = new SqlCommand("update from tblFood set Fprice = " + textBox2.Text + " where Fname = '" + textBox1.Text + "'", con);

            con.Open();
            int s = cmd.ExecuteNonQuery();
            if (s > 0)
            {
                MessageBox.Show("Food Item Updated");
            }
            else
            {
                MessageBox.Show("Food Item Not Updated");
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // view

            SqlCommand cmd = new SqlCommand("select * from tblFood", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
