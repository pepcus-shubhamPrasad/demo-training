using ObserverDesign.Subject;

namespace ObserverDesign.Deparments
{
    public interface Imanager
    {
        void AllocateImanager();
    }
    public class Manager : Imanager, IResignationObserver
    {
        public Manager(IResignation resignation)
        {
            resignation.AddObserver(this);
        }
        public void AllocateImanager()
        {
          //
        }

        public void Notify(string employeeId)
        {
           ///
        }
    }
}
