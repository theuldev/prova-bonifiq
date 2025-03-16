using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public abstract class BaseService<T> where T : class
    {
        protected readonly TestDbContext _ctx;
        protected BaseService(TestDbContext ctx) { 
            _ctx = ctx;
        }
        protected PaginatedList<T> GetListPaginated(int page)
        {
            var data = _ctx.Set<T>().AsQueryable();
            int total = data.Count();
            int offset = (page - 1) * 10;
            var items = data.Skip(offset).Take(10).ToList(); 
            var hasNext = (offset + 10) < total;
            return new PaginatedList<T>
            {
                HasNext = hasNext,
                TotalCount = total,
                Items = items
            };
        }
    }
}
