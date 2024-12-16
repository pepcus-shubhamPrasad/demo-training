using ObserverDesign.Deparments;

namespace ObserverDesign.Subject
{
    public class Resignation : IResignation
    {
        List<IResignationObserver> ObserversList;

        public Resignation()
        {
            ObserversList = new List<IResignationObserver>();
        }
        public void AddObserver(IResignationObserver observer)
        {
            ObserversList.Add(observer);
        }

        public void NotifyObserver(string employeeId)
        {
            foreach (var observer in ObserversList) {
                observer.Notify(employeeId);
            }
        }

        public void RemoveObserver(IResignationObserver observer)
        {
           ObserversList.Remove(observer);
        }
    }
}
