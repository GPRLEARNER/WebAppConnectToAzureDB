using System.Data.SqlClient;
using WebAppConnectToAzureDB.Models;

namespace WebAppConnectToAzureDB.Servcies
{
    public class ProductService : IProductService
    {
        private static string db_source = "serveradminazureconstring.database.windows.net";
        private static string db_user = "sqlserverdata";
        private static string db_password = "sqlusr@1234";
        private static string db_database = "serveradmin";

        public readonly  IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;
            //return new SqlConnection(_builder.ConnectionString);
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
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
