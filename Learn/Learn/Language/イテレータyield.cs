using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // https://ufcpp.net/study/csharp/sp2_iterator.html
    class イテレータyield
    {
        public イテレータyield()
        {
            Console.WriteLine("\r\nイテレータyield\r\n");

            // ↓こんな感じで使う。
            foreach (int i in FromTo(10, 20))
            {
                Console.Write("{0}\n", i);
            }
        }

        // ↓これがイテレーター ブロック。IEnubrable を実装するクラスを自動生成してくれる。
        static public IEnumerable<int> FromTo(int from, int to)
        {
            while (from <= to)
                yield return from++;
        }

    }
}
