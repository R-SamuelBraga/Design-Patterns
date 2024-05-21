using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public sealed class PrintSpooler
    {
        private static PrintSpooler _lazyInstance = null!;
        private static readonly object Padlock = new();

        private readonly Queue<string> _queue = new();

        private PrintSpooler()
        {

        }
        public static PrintSpooler GetPrintSpooler()
        {
        //Make it thread safe
            lock (Padlock)
            {
                return _lazyInstance ??= new PrintSpooler();
            }
        }

        public void AddPrintJob(IEnumerable<string> documents)
        {
            if (documents == null) throw new ArgumentNullException(nameof(documents));
            //Make it thread safe
            lock (_queue)
            {
                foreach (var document in documents) _queue.Enqueue(document);
            }
        }

        public void ProcessPrintJob()
        {
            //Make it thread safe
            lock (_queue)
            {
                foreach (var document in _queue) Console.WriteLine(document);
                Console.WriteLine("Instance Call Finished");
            }
        }
    }
}