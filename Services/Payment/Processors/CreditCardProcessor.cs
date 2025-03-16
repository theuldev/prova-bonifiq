namespace ProvaPub.Services.Payment.Processors.CreditCardProcessor
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool CanProcess(string paymentMethod) => paymentMethod == "creditcard";

        public Task ProcessPayment(decimal value, int customerId)
        {
            // Lógica específica para Pix
            throw new NotImplementedException();
        }
    }
}
