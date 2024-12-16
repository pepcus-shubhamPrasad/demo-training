namespace StrategyPattern.BusinessService
{
    public class CreditCardPayment : Ipaymentprocesser
    {
        public bool process(string BankDetail)
        {
            return true;
        }
    }
}
