using ClassWork.Countervariance;
using ClassWork.Covariance;
using System;

namespace ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Covariance
            ITest<BaseClass> implBase = new ImplClass();
            BaseClass baseC = implBase.Print("Hello");
            Console.WriteLine(baseC.Name);

            ITest<ChildClass> implChild = new ImplClass();
            ITest<BaseClass> impBase = implChild;
            BaseClass baseClass = impBase.Print("Hi!");
            Console.WriteLine(baseClass.Name);

            //Countervariance
            ITestCounter<ChildCounter> implChildCount = new ImplCounter();
            implChildCount.Print(new ChildCounter("Child!"));

            ITestCounter<BaseCounter> impBaseCount = new ImplCounter();
            ITestCounter<ChildCounter> testCounter = impBaseCount;

            testCounter.Print(new ChildCounter("Child!!!"));
            impBaseCount.Print(new BaseCounter("FFFF"));

            Console.ReadLine();     
        }
    }
}
