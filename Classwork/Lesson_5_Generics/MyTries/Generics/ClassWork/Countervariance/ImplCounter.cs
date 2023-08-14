using System;

namespace ClassWork.Countervariance
{
    public class ImplCounter : ITestCounter<BaseCounter>
    {
        public void Print(BaseCounter obj)
        {
            Console.WriteLine("Message from base obj: " + obj.Name);
        }
    }
}
