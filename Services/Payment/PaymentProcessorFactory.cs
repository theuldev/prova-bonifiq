namespace ProvaPub.Services.Payment
{
    public interface IPaymentProcessorFactory
    {
        IPaymentProcessor GetProcessor(string paymentMethod);
    }
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        private readonly IEnumerable<IPaymentProcessor> _processors;
        public PaymentProcessorFactory(IEnumerable<IPaymentProcessor> processors)
        {
            _processors = processors;
        }
        public IPaymentProcessor GetProcessor(string paymentMethod)
        {
            var processor = _processors.FirstOrDefault(p => p.CanProcess(paymentMethod));
            return processor ?? throw new NotSupportedException($"Método {paymentMethod} não suportado");
        }
    }
}
