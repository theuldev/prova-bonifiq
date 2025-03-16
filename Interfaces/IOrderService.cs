using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId);
    }
}
