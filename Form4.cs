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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = HotelDB; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Fname, Fprice from tblFood", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Fname from tblFood", con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
