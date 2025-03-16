
namespace ProvaPub.Services.Payment.Processors.PixProcessor
{
    public class PixProcessor : IPaymentProcessor
    {
        public bool CanProcess(string paymentMethod) => paymentMethod == "pix";


        public Task ProcessPayment(decimal value, int customerId)
        {
            // Lógica específica para Pix
            throw new NotImplementedException();
        }
    }
}
