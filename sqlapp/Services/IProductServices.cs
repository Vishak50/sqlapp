using sqlapp.Models;

namespace sqlapp.Services
{
    public interface IProductServices
    {
        List<Product> GetProducts();
    }
}