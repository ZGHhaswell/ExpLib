using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCollector
{
    class Program
    {
        static void Main(string[] args)
        {

            var backCollector = new BackCollector<string>();
            backCollector.BackgroundWorker.RunWorkerAsync();

            while(true)
            {
                string readLine = Console.ReadLine();
                backCollector.Queue.Enqueue(readLine);
            }
        }
    }
}
