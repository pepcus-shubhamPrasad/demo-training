namespace StrategyPattern.BusinessService
{
    public class DebitCardPayemnt : Ipaymentprocesser
    {
        public bool process(string BankDetail)
        {
            return true;
        }
    }
}
