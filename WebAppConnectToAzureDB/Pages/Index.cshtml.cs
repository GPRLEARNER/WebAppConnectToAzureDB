using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppConnectToAzureDB.Models;
using WebAppConnectToAzureDB.Servcies;

namespace WebAppConnectToAzureDB.Pages
{
    public class IndexModel : PageModel
    {
      public List<Product> productList;

        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {

            productList = _productService.GetProducts();

           
        }
    }
}