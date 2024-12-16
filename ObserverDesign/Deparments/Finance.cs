using ObserverDesign.Subject;

namespace ObserverDesign.Deparments
{
    public interface IFinance
    {
        void CalculateSalary();
    }
    public class Finance : IFinance , IResignationObserver
    {
        public Finance(IResignation resignation)
        {
            resignation.AddObserver(this);
        }
        public void CalculateSalary()
        {
            // 
        }

        public void Notify(string employeeId)
        {
            // whenever Employee Resign Notification Come Here
        }
    }
}
