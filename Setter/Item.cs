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
    public partial class Item : Form
    {

        DbConnection dbConnection = new DbConnection();
        ItemBLL itemBLL = new ItemBLL();

        public Item()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            this.Hide();

            customer_type customerType = new customer_type();

            customerType.ShowDialog();
            this.Close();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            /*
            String itemName = txtItemName.Text;
            float itemRate = float.Parse(txtItemRate.Text);

            // Sql script

            String insertItem = "insert into items(item_name, item_rate) values('" + itemName + "'," + itemRate + ");";

            dbConnection.manipulate(insertItem);
            MessageBox.Show("New item has been inserted, Successfully !!!");

            txtItemName.Text = txtItemRate.Text = "";
            retrieveItem();
            // this.Close();
            */


            // new code over here

            if (btnItemAdd.Text == "ADD")
            {
                if (txtItemName.Text == "")
                {
                    MessageBox.Show("Enter Item Name !!!");
                    txtItemName.Focus();
                    return;
                }
                else if (txtItemRate.Text == "")
                {
                    MessageBox.Show("Enter Item Rate !!!");
                    txtItemRate.Focus();
                    return;
                }
                else
                {
                    String itemName = txtItemName.Text;
                    int itemRate = int.Parse(txtItemRate.Text);

                    itemBLL._itemName = itemName;
                    itemBLL._itemRate = itemRate;

                    itemBLL.insertItem();

                    txtItemName.Text = txtItemRate.Text = "";

                    dgvItem.DataSource = itemBLL.retrieveItem();

                    txtItemName.Focus();
                    return;
                }
            }
            else if (btnItemAdd.Text == "UPDATE")
            {
                if (txtItemName.Text == "")
                {
                    MessageBox.Show("Enter Item Name !!!");
                    txtItemName.Focus();
                    return;
                }
                else if (txtItemRate.Text == "")
                {
                    MessageBox.Show("Enter Item Rate !!!");
                    txtItemRate.Focus();
                    return;
                }
                else
                {
                    String itemName = txtItemName.Text;
                    int itemRate = int.Parse(txtItemRate.Text);

                    itemBLL._itemName = itemName;
                    itemBLL._itemRate = itemRate;

                    itemBLL.updateItem(iCode);

                    txtItemName.Text = txtItemRate.Text = "";
                    btnItemAdd.Text = "ADD";

                    dgvItem.DataSource = itemBLL.retrieveItem();

                    txtItemName.Focus();
                    return;
                }
            }

        }

        private void retrieveItem()
        {
            String selectItem = "select item_id, item_name, item_rate from items order by item_id desc;";

            DataTable cn = dbConnection.retrieve(selectItem);
            dgvItem.DataSource = cn;
        }

        private void Item_Load(object sender, EventArgs e)
        {
            retrieveItem();
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // Write a code inside the Click event

        int iCode;

        private void dgvItem_Click(object sender, EventArgs e)
        {
            // important 
            int columnIndex = dgvItem.CurrentCell.ColumnIndex;  
            iCode = int.Parse(dgvItem.CurrentRow.Cells["item_id"].Value.ToString());

            // error occured in the uppermost code iCode section
            

            if (dgvItem.CurrentRow.Cells[columnIndex].Value.ToString() == "Edit")
            {
                btnItemAdd.Text = "UPDATE";
                DataTable dataTable = itemBLL.retrieveItemById(iCode);
                txtItemName.Text = dataTable.Rows[0][1].ToString();
                txtItemRate.Text = dataTable.Rows[0][2].ToString();
            }
            else if (dgvItem.CurrentRow.Cells[columnIndex].Value.ToString() == "Delete")
            {
                DialogResult diaglogResult = MessageBox.Show("Are you sure to delete the item ?", "Confirm  for delete ?", MessageBoxButtons.YesNo);

                if (diaglogResult == DialogResult.Yes)
                {
                    itemBLL.deleteItem(iCode);
                    txtItemName.Text = txtItemRate.Text = "";
                    dgvItem.DataSource = itemBLL.retrieveItem();
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // event for dashboard
            // not compulsary
        }
    }
}
