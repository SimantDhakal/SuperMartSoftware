using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setter
{
    class GenerateBLL
    {
        DbConnection dbConnection = new DbConnection();

        //Customer_CustomerType_Join
        public DataTable getCustomerWithType(int customerCode)
        {
            String selectSQL = "select fname, lname, addresses, customer_type_name, username, cpassword from customers c, customers_type ct where c.customer_type_id = ct.customer_type_id and c.customers_code = " + customerCode;
            DataTable cn = dbConnection.retrieve(selectSQL);
            return cn;
        }

        public String getItemRate(int itemCode)
        {
            String selectSQL = "select item_rate from items where item_id = " + itemCode;
            DataTable cn = dbConnection.retrieve(selectSQL);
            return cn.Rows[0][0].ToString();
        }

        public String getNewBillNum()
        {
            String insertSQL = "insert into Bill(customers_code, total, discount, vat, netTotal) values(null,null,null,null,null);";
            dbConnection.manipulate(insertSQL);
            String getLastBill = "SELECT TOP 1 bill_no FROM Bill ORDER BY bill_no DESC";
            DataTable cn = dbConnection.retrieve(getLastBill);
            return cn.Rows[0][0].ToString();
        }

        public DataTable addItemToBill(int billNum, int customerCode, int itemCode, int itemQuantity)
        {

            String updateBill = "update Bill set customers_code = " + customerCode + "where bill_no = " + billNum;
            String totalValue = "(select i.item_rate from items i where item_id = " + itemCode + ") * " + itemQuantity;
            String insertIntoItemBill = "insert into item_bill(bill_no, item_id, quantity, total) values(" + billNum + "," + itemCode + "," + itemQuantity + "," + totalValue + ")";

            dbConnection.manipulate(updateBill);
            dbConnection.manipulate(insertIntoItemBill);

            String selectSQL = "select i.item_name, i.item_rate, ib.quantity, ib.total from items i, item_bill ib where i.item_id = ib.item_id and bill_no = +" + billNum + ";";
            DataTable cn = dbConnection.retrieve(selectSQL);
            return cn;
        }

        /*
        public String calculateGrandTotal(int billNumber)
        {
            String sql = "select SUM(total) from ItemBill where billNo = " + billNumber;
            DataTable dataTable = dbConnection.retrieve(sql);
            return dataTable.Rows[0][0].ToString();
        }

        public void addBillDetails(int billNum, float grandTotal, float discount, float vat, float netTotal)
        {
            String sql = "update Bill set grandTotal = " + grandTotal + ", discount = " + discount + ", vat = " + vat + ", netTotal = " + netTotal + " where billNo = " + billNum;
            dbConnection.manipulate(sql);
        }
        */
    }
}
