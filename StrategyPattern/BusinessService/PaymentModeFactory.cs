namespace StrategyPattern.BusinessService
{
    public class PaymentModeFactory
    {
        public Ipaymentprocesser CreateStrategy(string mode)
        {
            if (mode == "Creadit Card")
            {
                return new CreditCardPayment();
            }
            return new DebitCardPayemnt();
        }
    }
}
