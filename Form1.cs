using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // navigate - form2- new entry
            
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // navigate -form3- billing

            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // navigate -form3- billing

            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
}
