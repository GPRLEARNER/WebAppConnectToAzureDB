using System.Data.SqlClient;
using WebAppConnectToAzureDB.Models;

namespace WebAppConnectToAzureDB.Servcies
{
    public interface IProductService
    {
        SqlConnection GetConnection();
        List<Product> GetProducts();
    }
}