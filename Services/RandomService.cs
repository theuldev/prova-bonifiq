using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
        TestDbContext _ctx;
		public RandomService()
        {
            var contextOptions = new DbContextOptionsBuilder<TestDbContext>()
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Teste;Trusted_Connection=True;")
    .Options;
            seed = Guid.NewGuid().GetHashCode();

            _ctx = new TestDbContext(contextOptions);
        }
        public async Task<int> GetRandom()
		{
            Random random = new(seed);
            int number;
            do
            {
                number = random.Next(100);

            } while (_ctx.Numbers.Any(n => n.Number == number));

            _ctx.Numbers.Add(new RandomNumber() { Number = number });
            _ctx.SaveChanges();

            return number;

        }

	}
}
