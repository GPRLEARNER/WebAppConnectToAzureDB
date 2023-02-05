using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppConnectToAzureDB.Models;
using WebAppConnectToAzureDB.Servcies;

namespace WebAppConnectToAzureDB.Pages
{
    public class IndexModel : PageModel
    {
      public List<Product> productList;


        public void OnGet()
        {
            productList = new List<Product>();
            ProductService prodcuctService = new();

            productList = prodcuctService.GetProducts();

           
        }
    }
}