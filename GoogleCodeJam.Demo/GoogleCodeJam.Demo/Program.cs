using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleCodeJam.Demo.Implementations;

namespace GoogleCodeJam.Demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Create simple queue.
            var simpleQueue = new SimpleQueue();

            // Create queue configurator.
            var queueConfiguration = new MagicQueueConfiguration();

            // Create magic queue mased on configurator and simple queue.
            var queue = new MagicQueue(simpleQueue, queueConfiguration);

            // Create new magic man.
            var magicMan = new MagicMan(queue);

            // Configure queue.
            // Q+F traslated into T
            queueConfiguration.AddCombine('Q', 'F', 'T');

            // Q&F will clear the queue.
            queueConfiguration.AddOpposed('Q', 'F');

            // Do magic.
            magicMan.InvokeElements("FAQFDFQ");

            // Take result.
            var res = simpleQueue.Result;

            Console.WriteLine(res);
        }
    }
}
