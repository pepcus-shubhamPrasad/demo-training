namespace StrategyPattern.BusinessService
{
    public interface Ipaymentprocesser
    {
        bool process(string BankDetail);
    }
}
