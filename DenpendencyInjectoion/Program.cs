using System;

namespace DependencyInjection
{
    /*
    class ClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB
    {
        ClassC c_dependency;
        public ClassB(ClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        ClassB b_dependency;
        public ClassA(ClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    */


    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");

        public void ActionC() => Console.WriteLine("Action in ClassC");
       
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ClassC objC = new ClassC();
            ClassB objB = new ClassB(objC);
            ClassA objA = new ClassA(objB);
            */

            IClassC objC = new ClassC();
            IClassB objB = new ClassB(objC);
            ClassA objA = new ClassA(objB);

            objA.ActionA();


        }
    }
}
