using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class 演算子
    {
        // https://ufcpp.net/study/csharp/st_operator.html

        public 演算子()
        {
            #region 演算子

            Console.WriteLine("演算子\r\n");

            // 「/」
            int a = 9 / 2; // 整数の場合、あまり切り捨て。 a は 4 になる。
            double x = 9.0 / 2.0; // a は 4.5 になる。
            Console.WriteLine($"{a}, {x}");



            // 「%」
            a = 9 % 2; // a は 1 になる。
            x = 9.5 % 2.0; // 1.5
            Console.WriteLine($"{a}, {x}");



            // 「+x」
            a = +1; // a = 1 と同じ
            Console.WriteLine($"a = +1 : {a}");



            // 「++x」と「x++」
            a = 5;
            ++a; // a = a + 1 と同じ
            Console.WriteLine($"++a : {a}"); // 6

            a = 5;
            a++; // a = a + 1 と同じ
            Console.WriteLine($"a++ : {a}"); // 6

            // 違いは評価順序
            a = 5;
            int b = ++a; // a も b も 6 になる。
            Console.WriteLine($"b = ++a : a={a} b={b}");

            a = 5;
            b = a++; // a は 6 に、b は 5 になる。
            Console.WriteLine($"b = a++ : a={a} b={b}");

            // - も同じ
            a = 5;
            b = --a; // a も b も 4 になる。 
            Console.WriteLine($"b = --a : a={a} b={b}");

            a = 5;
            b = a--; // a は 4 に、b は 5 になる。
            Console.WriteLine($"b = a-- : a={a} b={b}");

            for(int i = 0;  i < 5; i++)
            {
                // 0, 1, 2, 3, 4,
                Console.Write($"{i},");
            }
            Console.WriteLine();

            for (int i = 0; i < 5; ++i)
            {
                // 0, 1, 2, 3, 4,
                Console.Write($"{i},");
            }
            Console.WriteLine();

            a = 0;
            for (int i = 0; i < 5; a = i++)
            {
                // aに代入した後にi++される
                // 0:0, 1:0, 2:1, 3:2, 4:3, 
                Console.Write($"{i}:{a}, ");
            }
            Console.WriteLine();

            a = 0;
            for (int i = 0; i < 5; a = ++i)
            {
                // i++した後にaに代入される
                // 0:0, 1:1, 2:2, 3:3, 4:4,
                Console.Write($"{i}:{a}, ");
            }
            Console.WriteLine();


            // 「x += y」
            a = 5;
            a += 10; // a = a + 10;と同じ
            Console.WriteLine($"a += 10 : {a}"); // a は 15 になる。



            // 「x ??= y」
            string s = null;
            s ??= "default string"; // if (s == null) s = ...; 
            s ??= "popopop"; // s != null なので実行されない
            Console.WriteLine($"??= : {s}");



            // 「x = y ?? z」
            s = null;
            var str = s ?? "is null"; // if(s == null) str = ...;
            // 「??=」とは異なり、s自体に変化はない
            Console.WriteLine($"{str}, {s}");



            // 「?:」三項演算子
            a = 4;
            s = (a > 5) ? "Bigger than 5." : "Smaller Than 5.";
            Console.WriteLine($"{a} is {s}");

            #endregion
        }
    }
}
