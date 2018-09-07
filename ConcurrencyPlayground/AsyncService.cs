using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyPlayground
{
    public class AsyncService
    {
        public async Task<bool> DoSomething(int waitDuration)
        {
            await Task.Run(() => Thread.Sleep(waitDuration));

            return true;
        }
    }
}
