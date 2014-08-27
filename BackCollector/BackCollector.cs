using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BackCollector
{
    public class BackCollector<T>
    {
        public Queue<T> Queue { get; private set; }



        public BackgroundWorker BackgroundWorker { get; private set; }


        public void EnterQueue(T t)
        {
            lock(typeof(BackCollector<T>))
            {
                Queue.Enqueue(t);
            }
        }

        public BackCollector()
        {
            Queue = new Queue<T>();
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                lock(typeof(BackCollector<T>))
                {
                    if (Queue.Count != 0)
                    {
                        var str = Queue.Peek();
                        if (str != null)
                        {
                            Console.WriteLine("Collect: " + str);
                            Queue.Dequeue();
                        }
                    }
                }
                
                
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
