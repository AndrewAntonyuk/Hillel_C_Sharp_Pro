namespace ClassWork
{
    public interface ICountervariance<in T>
    {
        T testFunc(string val);//<- there is fault

        void testFunc(T val);
    }

    public interface ICovariance<out T>
    {
        T testFunc(string val);

        void testFunc(T val);//<- there is fault
    }
}
