using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class is拡張
    {
        // https://ufcpp.net/study/csharp/oo_polymorphism.html
        // https://ufcpp.net/study/csharp/datatype/typeswitch/#is

        public is拡張()
        {
            #region is拡張

            Console.WriteLine("is拡張\r\n");

            // castの続き

            var obj = "string";

            // isは少しめんどくさい
            if (obj is string)
            {
                var tmp = (string)obj;
                //↑ isとキャストで2つの別命令を使う。二重処理になってるだけで無駄
                Console.WriteLine("string #" + tmp.Length);
            }

            // C# 7では、is演算子で以下のような書き方ができるようになった
            if (obj is string s)
            {
                Console.WriteLine("string #" + s.Length);
            }

            // nullの場合は注意！
            string x = null;
            if (x is string)
            {
                // x の変数の型は string なのに、is string は false
                // is 演算子は変数の実行時の中身を見る ＆ null には型がない
                Console.WriteLine("ここは絶対通らない");
            }

            // これを逆に利用して、Nullableな型のチェックに使える
            int? hoge = 1;
            if(hoge is int i)
            {
                Console.WriteLine($"{i} is not null.");
            }

            // Nullableな型に対して、単純にnullかどうかチェックした場合は、HasValueプロパティがある
            if (hoge.HasValue)
            {
                Console.WriteLine($"{hoge} is not null.");
                int fuga = (int)hoge; // もちろんダウンキャストが必要
            }

            #endregion
        }
    }
}
