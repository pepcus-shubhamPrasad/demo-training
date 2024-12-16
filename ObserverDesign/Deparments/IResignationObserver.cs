namespace ObserverDesign.Deparments
{
    public interface IResignationObserver
    {
        void Notify(string employeeId);
    } 
}
