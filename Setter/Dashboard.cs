using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setter
{
    public partial class Dashboard : Form
    {

        private string username;

        public Dashboard(string username)
        {

            this.username = username;

            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {



        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblmain.Text = username;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();

            // pass activity
            customer_type customerType = new customer_type();
            customerType.ShowDialog();

            // close
            this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();

            Customer customer = new Customer();
            customer.ShowDialog();

            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();

            // defined and passed the activity
            Form1 form1 = new Form1();
            form1.ShowDialog();

            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            this.Hide();

            // defined and passed the activity
            customer_type customerType = new customer_type();
            customerType.ShowDialog();

            this.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();

            Bill bill = new Bill();
            bill.ShowDialog();

            this.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Hide();

            Item item = new Item();
            item.ShowDialog();

            this.Close();
        }
    }
}
