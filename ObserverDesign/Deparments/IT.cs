using ObserverDesign.Subject;

namespace ObserverDesign.Deparments
{
    public interface IAsset
    {
        void AllocateAsset();
    }
    public class IT : IAsset, IResignationObserver
    {
        public IT(IResignation resignation) {
            resignation.AddObserver(this);
        }
        public void AllocateAsset()
        {
        }

        public void Notify(string employeeId)
        {
            //
        }
    }
}
