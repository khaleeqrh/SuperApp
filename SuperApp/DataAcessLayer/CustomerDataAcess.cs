using Dapper;
using SuperApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace SuperApp.DataAcessLayer
{
    public class CustomerDataAcess
    {

        public List<CustomerModel> GetCustomers()
        {
            using (IDbConnection cnn = new SQLiteConnection(@"Data Source =.\chinook.db; Version = 3;"))
            {
                var data = cnn.Query<CustomerModel>("SELECT * FROM Customers;").ToList();
                return data;
            }
        }

        public CustomerModel GetCustomer(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(@"Data Source =.\chinook.db; Version = 3;"))
            {
                var data = cnn.Query<CustomerModel>($"SELECT * FROM Customers WHERE CustomerId = @ID;", new { ID = id }).SingleOrDefault();
                return data;
            }
            
        }
    }
}
