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
    public partial class Bill : Form
    {

        DbConnection dbConnection = new DbConnection();
        GenerateBLL generateBLL = new GenerateBLL();

        public Bill()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();

            Customer customer = new Customer();
            customer.ShowDialog();

            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            this.Hide();

            customer_type customerType = new customer_type();
            customerType.ShowDialog();

            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 form1 = new Form1();
            form1.ShowDialog();

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
            String selectItem = "select customers_code, total, discount, netTotal, vat from Bill order by customers_code asc;";

            DataTable cn = dbConnection.retrieve(selectItem);
            dgvItem.DataSource = cn;
        }

        private void Bill_Load(object sender, EventArgs e)
        {

            // to generate a bill number
            // txtBillNo.Text = generateBLL.getNewBillNum();

            // load the combo box data
            // cmbItemName.Text = generateBLL.getNewBillNum();
            // cmbItemName.DisplayMember = "item_name";
            // cmbItemName.ValueMember = "item_id";


            retrieveItem();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerCode.Text == "")
            {
                txtfname.Text = txtlname.Text = txtaddress.Text = "null";
            }
            else
            {
                int customerCode = int.Parse(txtCustomerCode.Text);

                if (customerCode <= 0)
                {
                    MessageBox.Show("Enter valid customer code !!!");
                }
                else
                {
                    
                    DataTable cn = generateBLL.getCustomerWithType(customerCode);
                    txtfname.Text = cn.Rows[0][0].ToString();
                    txtlname.Text = cn.Rows[0][1].ToString();
                    txtaddress.Text = cn.Rows[0][2].ToString();
                    txtCtype.Text = cn.Rows[0][3].ToString();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
