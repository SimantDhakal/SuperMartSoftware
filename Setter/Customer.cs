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
    public partial class Customer : Form
    {

        DbConnection dbConnection = new DbConnection();

        public Customer()
        {
            InitializeComponent();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 form1 = new Form1();
            form1.ShowDialog();

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

        private void label21_Click(object sender, EventArgs e)
        {
            this.Hide();

            customer_type customerType = new customer_type();
            customerType.ShowDialog();

            this.Close();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            String query;
            query = "select customer_type_name, customer_type_id from Customers_type";
            DataTable cn = dbConnection.retrieve(query);
            rdoType.DataSource = cn;
            rdoType.DisplayMember = "customer_type_name";
            rdoType.ValueMember = "customer_type_id";

            retrieveItem();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String cFirst = txtFirst.Text;
            String cLast = txtLast.Text;
            String cAddress = txtAddress.Text;
            String cPhone = txtPhone.Text;
            String DOB = txtDOB.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String cgender;

            // condition for radio button
            cgender = "null";
            if (rdoMale.Checked == true)
            {
                cgender = "M";
            }
            else if (rdoFemale.Checked == true)
            {
                cgender = "F";
            }
            else
            {
                MessageBox.Show("Please select gender!");
                return;
            }

            // Sql script

            String insertItem = "insert into customers(customer_type_id, fname, lname, phone, gender, DOB, addresses, username, cpassword) values('" + rdoType.SelectedValue + "','" + cFirst + "','" + cLast + "','" + cPhone + "','" + cgender + "','" + DOB + "','" + cAddress + "','" + username + "','" + password + "');";

            dbConnection.manipulate(insertItem);
            MessageBox.Show("New item has been inserted, Successfully !!!");

            // clear the field after insert
            txtFirst.Text = txtLast.Text = "";
            txtPassword.Text = txtPhone.Text = "";
            txtUsername.Text = txtPassword.Text = "";
            txtDOB.Text = txtAddress.Text = "";
            retrieveItem();
            // this.Close();
        }


        private void retrieveItem()
        {
            String selectItem = "select customers_code, customer_type_id, fname, lname, phone, gender, addresses, DOB, username, cpassword from customers order by customers_code desc;";

            DataTable cn = dbConnection.retrieve(selectItem);
            dgvCustomer.DataSource = cn;
        }

        private void cmdCtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
