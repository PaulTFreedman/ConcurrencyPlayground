using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyPlayground
{
    public class DemoRunner
    {
        Stopwatch stopwatch;

        public void Run()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            LongRunningOperationSync();

            ExecuteSync();

            ExecuteAsync().Wait();

            stopwatch.Stop();
        }

        private void LongRunningOperationSync()
        {
            Console.WriteLine("Beginning processing of synchronous code from synchronous method");
            var startTime = stopwatch.ElapsedMilliseconds;

            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);

            Console.WriteLine("Finished! Duration: " + (stopwatch.ElapsedMilliseconds - startTime) + " (ms)\n");
        }

        private void ExecuteSync()
        {
            Console.WriteLine("Beginning processing of async code from synchronous method");
            var startTime = stopwatch.ElapsedMilliseconds;
            var asyncService = new AsyncService();

            // Code initiates the work but does not wait for it to finish
            var result1 = asyncService.DoSomething(1000);
            var result2 = asyncService.DoSomething(1000);
            var result3 = asyncService.DoSomething(1000);

            Console.WriteLine("Finished! Duration: " + (stopwatch.ElapsedMilliseconds - startTime) + " (ms)\n");
        }

        private async Task ExecuteAsync()
        {
            Console.WriteLine("Beginning processing of async code from async method");
            var startTime = stopwatch.ElapsedMilliseconds;
            var asyncService = new AsyncService();

            var task1 = asyncService.DoSomething(1000);
            var task2 = asyncService.DoSomething(1000);
            var task3 = asyncService.DoSomething(1000);

            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("Finished! Duration: " + (stopwatch.ElapsedMilliseconds - startTime) + " (ms)\n");
        }
    }
}
