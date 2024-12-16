using ObserverDesign.Subject;

namespace ObserverDesign.Deparments
{
    public interface IHR
    {
        void HrLocated();
    }
    public class HR : IHR, IResignationObserver
    {
        public HR(IResignation resignation)
        {
            resignation.AddObserver(this);
        }
        public void HrLocated()
        {
            
        }
        public void Notify(string employeeId)
        {
            
        }
    }
}
