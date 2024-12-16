namespace StrategyPattern.BusinessService
{
    public class Context
    {
        private Ipaymentprocesser _processor;

        public void SetpayemntStrategy(Ipaymentprocesser processor)
        {
            _processor = processor;
        }
        public bool ProcessPayment(string bankDetail)
        {
            return _processor.process(bankDetail);
        }
    }
}
