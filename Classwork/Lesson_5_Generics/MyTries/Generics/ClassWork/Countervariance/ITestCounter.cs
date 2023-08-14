namespace ClassWork.Countervariance
{
    public interface ITestCounter <in T> where T : class
    {
        void Print(T text);
    }
}
