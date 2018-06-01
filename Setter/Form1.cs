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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        loginBill loginbill = new loginBill();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginbill._username = txtUsername.Text;
            loginbill._password = txtPassword.Text;

            bool isValidUser = loginbill.checkUser();

            if (isValidUser)
            {
                this.Hide();

                Dashboard dashboard = new Dashboard(txtUsername.Text);
                dashboard.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Enter valid username or password.");
            }
        }
    }
}
