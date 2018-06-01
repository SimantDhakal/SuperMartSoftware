using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setter
{
    class ItemBLL
    {

        private String itemName;
        private int itemRate;
        

        public ItemBLL(String itemName, int itemRate)
        {
            this.itemName = itemName;
            this.itemRate = itemRate;
        }

        public ItemBLL()
        {
        }

        public String _itemName
        {
            get { return itemName; }
            set { this.itemName = value; }
        }

        public int _itemRate
        {
            get { return itemRate; }
            set { this.itemRate = value; }
        }

        //Database
        DbConnection dbConnection = new DbConnection();


        public void insertItem()
        {
            String insertItem = "insert into items(item_name, item_rate) values('" + itemName + "'," + itemRate + ");";
            dbConnection.manipulate(insertItem);
        }

        public DataTable retrieveItem()
        {
            String selectItem = "select item_id, item_name, item_rate from items order by item_name asc;";
            DataTable dataTable = dbConnection.retrieve(selectItem);

            return dataTable;
        }

        public void updateItem()
        {
            
        }

        internal void updateItem(int item_id)    
        {
            String updateItem = "update items set item_name = '" + itemName + "', item_rate = '" + itemRate + "' where item_id = " + item_id;
            dbConnection.manipulate(updateItem);
        }

        internal DataTable retrieveItemById(int id)
        {
            String selectItem = "select item_id, item_name, item_rate from items where item_id = " + id + ";";
            DataTable dataTable = dbConnection.retrieve(selectItem);

            return dataTable;
        }

        public void deleteItem(int id)
        {
            String query = "delete from items where item_id = " + id;
            dbConnection.manipulate(query);
        }
    }
}
