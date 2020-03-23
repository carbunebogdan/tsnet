using System;
using System.Threading;

namespace l1
{
    public class EventClass
    {
        public delegate void ComputationDoneEventHandler(object source, EventArgs args);
        public event ComputationDoneEventHandler ComputationDone;

        public EventClass()
        {
        }


        protected virtual void OnComputationDone()
        {
            if(ComputationDone != null)
            {
                ComputationDone(this, EventArgs.Empty);
            }
        }

        public void Compute()
        {
            Console.WriteLine("Computing...");
            Thread.Sleep(1000);
            OnComputationDone();
        }
    }
}
