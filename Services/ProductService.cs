using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService : BaseService<Product>, IProductService
	{

		public ProductService(TestDbContext ctx): base(ctx){}

		public PaginatedList<Product> ListProducts(int page)
		{
			return GetListPaginated(page);
		}

	}
}
