using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setter
{
    class loginBill
    {

        private string username;
        private string password;

        public string _username
        {
            get { return username; }
            set { username = value; }
        }

        public string _password
        {
            get { return _password; }
            set { password = value; }
        }

        DbConnection conn = new DbConnection();

        public bool checkUser()
        {
            string query;
            query = "select username from customers where username = '" + username + "' and cpassword = '" + password + "'";
            DataTable dt = conn.retrieve(query);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
