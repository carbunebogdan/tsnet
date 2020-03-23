using System;
using System.Threading;

namespace l1
{
    class Program
    {
        static void Main(string[] args)
        {
            //problema1();
            problema2();
        }

        static void problema1()
        {
            var eventClass = new EventClass();
            var exampleClass = new ExampleClass();

            eventClass.ComputationDone += exampleClass.OnComputationDone;
            eventClass.Compute();
        }

        static void problema2()
        {
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread1 = new Thread(() => Metoda1(5));
            childThread1.Start();
            Thread childThread2 = new Thread(() => Metoda2(6));
            childThread2.Start();
        }

        public static void Metoda1(int number)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "Thread-ul pentru metoda1";
            Console.WriteLine("Start fir: {0}-{1}. Numar natural dat = {2}",th.Name, new DateTime().ToString("hh:mm:ss.ff"), number);
            Thread.Sleep(1504);
            Console.WriteLine("Sfarsit fir: {0}", new DateTime().ToString("hh:mm:ss.ff"));
        }

        public static void Metoda2(int number)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "Thread-ul pentru metoda2";
            Console.WriteLine("Start fir: {0}-{1}. Numar natural dat = {2}", th.Name, new DateTime().ToString("hh:mm:ss.ff"), number);
            Thread.Sleep(999);
            Console.WriteLine("Sfarsit fir: {0}", new DateTime().ToString("hh:mm:ss.ff"));
        }
    }

    class ExampleClass
    {
        public void OnComputationDone(object source, EventArgs e)
        {
            Console.WriteLine("Computation Finished!");
        }
    }
}
