using System.Data.SqlClient;
using WebAppConnectToAzureDB.Models;

namespace WebAppConnectToAzureDB.Servcies
{
    public class ProductService
    {
        public const string db_source = "serveradminlogin.database.windows.net";
        public const string db_database = "AzureDB";
        public const string db_user = "sqlserverdata";
        public const string db_password = "sqlusr@1234";


        public SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection cn = GetConnection();

            List<Product> _products = new List<Product>();

            string stmt = " Select ProductID, ProductName, Quantity from Products";
            cn.Open();
            var cmd = new SqlCommand(stmt, cn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product prodcut = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _products.Add(prodcut);
                }
            }
            cn.Close();
            return _products;
        }
    }
}
