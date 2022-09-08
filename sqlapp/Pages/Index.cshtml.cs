using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Models;
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        private readonly IProductServices _productServices;

        public IndexModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public void OnGet()
        {
            Products = _productServices.GetProducts();
        }
    }
}