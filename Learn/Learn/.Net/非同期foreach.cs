using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Net
{
    // https://qiita.com/muniel/items/d91cd61b912e4c2938a9

    public class 非同期foreach
    {
        private 非同期foreach()
        {
            
        }

        public static async Task<非同期foreach> Create()
        {
            Console.WriteLine("\r\n非同期foreach\r\n");

            非同期foreach myClass = new 非同期foreach();

            await myClass.DoSomething();

            return myClass;
        }

        async Task DoSomething()
        {
            await foreach (var item in DoAsync())
            {
                Console.WriteLine(item);
            }
        }

        private async IAsyncEnumerable<int> DoAsync()
        {
            foreach (var item in Enumerable.Range(1, 50).Select(x => x * 5))
            {
                await Task.Delay(item);
                yield return item;
            }
        }
    }
}
