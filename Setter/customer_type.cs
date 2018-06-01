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
    public partial class customer_type : Form
    {

        DbConnection dbConnection = new DbConnection();

        public customer_type()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
          
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();

            // defined and passed the activity
            Form1 form1 = new Form1();
            form1.ShowDialog();

            this.Close();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            this.Hide();

            // defined and passed the activity
            Bill bill = new Bill();
            bill.ShowDialog();

            this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();

            Customer customer = new Customer();
            customer.ShowDialog();

            this.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Hide();

            Item item = new Item();
            item.ShowDialog();

            this.Close();
        }

        private void retrieveItem()
        {
            String selectItem = "select customer_type_name, customer_type_id from Customers_type order by customer_type_id asc;";

            DataTable cn = dbConnection.retrieve(selectItem);
            dgvItem.DataSource = cn;
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            String Name = txtName.Text;

            // Sql script

            String insertItem = "insert into customers_type(customer_type_name) values('" + Name + "')";

            dbConnection.manipulate(insertItem);
            MessageBox.Show("New item has been inserted, Successfully !!!");

            retrieveItem();
            // this.Close();

        }

        private void customer_type_Load(object sender, EventArgs e)
        {
            retrieveItem();
        }
    }
}
