namespace ProvaPub.Services.Payment
{
    public interface IPaymentProcessor
    {
        bool CanProcess(string paymentMethod);
        Task ProcessPayment(decimal value, int customerId);
    }
}
