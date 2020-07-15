using Marmot.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marmot.Test
{
    class Program
    {
        private static async Task<int> test2()
        {
            int a = await Task.Factory.StartNew<int>(() =>
            {
                Console.WriteLine("5 " + Thread.CurrentThread.ManagedThreadId);
                return 1;
            });
            Console.WriteLine("6 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("21212121");
            return a;
        }

        private static async void test() 
        {
            Console.WriteLine("3 " + Thread.CurrentThread.ManagedThreadId);
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            //await test2();
            Console.WriteLine("4 " + Thread.CurrentThread.ManagedThreadId);
            OneThreadSynchronizationContext.Instance.Start();
             test2();
        }

        static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            var app = new Application();
            app.Start();
            OneThreadSynchronizationContext.Instance.Start();

            Console.WriteLine("1 " + Thread.CurrentThread.ManagedThreadId);
            test();
            Console.WriteLine("2 " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
