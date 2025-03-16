using Microsoft.OpenApi.Extensions;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Payment;

namespace ProvaPub.Services
{
	public class OrderService : IOrderService
	{
		private readonly IPaymentProcessorFactory _paymentProcessorFactory;
        TestDbContext _ctx;

        public OrderService(TestDbContext ctx, IPaymentProcessorFactory paymentProcessorFactory)
        {
            _ctx = ctx;
			_paymentProcessorFactory = paymentProcessorFactory;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{

			var processor = _paymentProcessorFactory.GetProcessor(paymentMethod);
			await processor.ProcessPayment(paymentValue,customerId);
            var brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brazilTimeZone);


            return await InsertOrder(new Order() //Retorna o pedido para o controller
            {
                Value = paymentValue,
				CustomerId = customerId,
				OrderDate = localTime
            });


		}

		public async Task<Order> InsertOrder(Order order)
        {
			//Insere pedido no banco de dados
			return (await _ctx.Orders.AddAsync(order)).Entity;
        }
	}
}
