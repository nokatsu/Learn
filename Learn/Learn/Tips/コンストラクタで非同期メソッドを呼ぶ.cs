using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Tips
{
    public class コンストラクタで非同期メソッドを呼ぶ
    {
        private コンストラクタで非同期メソッドを呼ぶ()
        {
            // ここはprivateにする
        }

        public static async Task<コンストラクタで非同期メソッドを呼ぶ> Create()
        {
            Console.WriteLine("\r\nコンストラクタで非同期メソッドを呼ぶ\r\n");

            コンストラクタで非同期メソッドを呼ぶ myClass = new コンストラクタで非同期メソッドを呼ぶ();

            await myClass.DoSomething();

            return myClass;
        }

        async Task DoSomething()
        {
            await Task.Delay(500);
        }
    }
}
