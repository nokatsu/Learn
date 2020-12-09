using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class 静的な型と動的な型
    {
        // https://ufcpp.net/study/csharp/oo_polymorphism.html

        class Base { }
        class Derived : Base { }

        public 静的な型と動的な型()
        {
            #region 静的な型と動的な型

            Console.WriteLine("静的な型と動的な型\r\n");

            // 派生クラスのインスタンスは基底クラスの変数に格納することが出来る。 
            // このとき、変数の型を静的な型といい、 実際に格納されているインスタンスの型を動的な型という。

            // 変数の型
            // ｜         実際に格納するインスタンスの型
            // ｜         ｜
            // ↓         ↓               静的な型, 動的な型
            Base a = new Base();        // Base    , Base
            Base b = new Derived();     // Base    , Derived
            Derived c = new Derived();  // Derived , Derived

            // 静的な型はtypeof(クラス名)で取得可能
            var type = typeof(Derived);

            // 動的な型は変数名.GetType()で取得可能
            var runType = c.GetType();

            Console.WriteLine($"{type}");
            Console.WriteLine($"{runType}");

            #endregion
        }
    }
}
