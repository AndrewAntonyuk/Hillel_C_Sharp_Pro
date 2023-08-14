namespace ClassWork.Covariance
{
    public interface ITest<out T>
    {
        T Print(string text);
    }
}
