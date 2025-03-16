namespace ProvaPub.Services.Payment.Processors.PayPalProcessor
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public bool CanProcess(string paymentMethod) => paymentMethod == "paypal";

        public Task ProcessPayment(decimal value, int customerId)
        {
            // Lógica específica para Pix
            throw new NotImplementedException();
        }
    }
}

