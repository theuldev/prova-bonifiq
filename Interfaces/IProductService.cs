using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IProductService
    {
        PaginatedList<Product> ListProducts(int page);
    }
}
