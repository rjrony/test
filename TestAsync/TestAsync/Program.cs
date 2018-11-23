using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAsync().Wait();
            //TestAsync().RunSynchronously();
            //TestAsync().ConfigureAwait();
            //TestAsync().ContinueWith();

            Console.WriteLine("end of the main()....");
            Console.ReadKey();
        }


        private static async Task TestAsync()
        {
            Task<int> longRunningTask = LongRunningOperation();
            Task<int> longRunningTask2 = LongRunningOperation2();
            //indeed you can do independent to the int result work here 
            MySynchronousMethod();
            //and now we call await on the task 
            int result2 = await longRunningTask2;
            int result = await longRunningTask;
            //use the result 
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }

        private static void MySynchronousMethod()
        {
            Console.WriteLine("synch call....");
        }

        public static async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            await Task.Delay(5000); //5 seconds delay
            return 1;
        }

        public static async Task<int> LongRunningOperation2() // assume we return an int from this long running operation 
        {
            await Task.Delay(10000); //5 seconds delay
            return 2;
        }

    }
}
