namespace ClassWork.Covariance
{
    public class ImplClass : ITest<ChildClass>
    {
        public ChildClass Print(string text)
        {
            return new ChildClass("I am child class: " +text);
        }
    }
}
