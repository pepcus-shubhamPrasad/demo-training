using ObserverDesign.Deparments;

namespace ObserverDesign.Subject
{
    public interface IResignation
    {
        void AddObserver(IResignationObserver observer);
        void RemoveObserver(IResignationObserver observer);
        void NotifyObserver(string employeeId);
    }
}
