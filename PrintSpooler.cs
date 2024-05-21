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
        //fila nativa c#
        private readonly Queue<string> _queue = new();

        private PrintSpooler()
        {

        }
        public static PrintSpooler GetPrintSpooler()
        {
            //instrução lock garante que, no máximo, apenas um thread execute seu corpo a qualquer momento
            lock (Padlock)
            {
                return _lazyInstance ??= new PrintSpooler();
            }
        }

        public void AddPrintJob(IEnumerable<string> documents)
        {
            if (documents == null) throw new ArgumentNullException(nameof(documents));
            lock (_queue)
            {
                foreach (var document in documents) _queue.Enqueue(document);
            }
        }

        public void ProcessPrintJob()
        {
            lock (_queue)
            {
                foreach (var document in _queue) Console.WriteLine(document);
                Console.WriteLine("Instance Call Finished");
            }
        }
    }
}
