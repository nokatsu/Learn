using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class cast
    {
        // https://ufcpp.net/study/csharp/oo_polymorphism.html

        class Base { }
        class Derived1 : Base { }
        class Derived2 : Base { }

        public cast()
        {
            #region cast

            Console.WriteLine("cast\r\n");

            // 基底クラスの変数に派生クラスの変数を渡すことをアップキャスト（upcast）と呼び、 
            // 逆に、 派生クラスの変数に基底クラスの変数を渡すことをダウンキャスト（downcast）と呼ぶ。

            Derived1 d1 = new Derived1(); // 当然、合法。
            Derived2 d2 = new Derived2(); // 同じく、合法。

            Base b;
            Derived1 d;

            b = d1;          // アップキャストは常に合法。明示的なキャスト不要。
            d = (Derived1)b; // ダウンキャストは明示的なキャストが必要。
                             // Derived1 の変数に Derived1 のインスタンスを格納しているので、これはOK。

            b = d2;          // 同じ事を今度は d2 の方で繰り返す。
            //d = (Derived1)b;
            // Derived1 の変数に Derived2 のインスタンスを格納しているので、これは問題あり。
            // コンパイルは通るが、実行時エラーになる。


            // このような問題があるため、ダウンキャストを行う際には動的な型情報を取得する必要がある。
            // そのための構文として C# には is 演算子と as 演算子がある。

            // is 演算子を適用した結果は bool 型になり、 左辺の変数が右辺の型にキャスト可能ならば true を、不能ならば false を返す。
            b = new Derived1();
            if (b is Derived1) // true
                Console.Write("b = new Derived1();\n");

            b = new Derived2();
            if (b is Derived1) // false
                Console.Write("b = new Derived2();\n");

            // as 演算子はキャストと同じような働きをする演算子で、もし型変換が出来ない場合には結果が null になる
            b = new Derived1();
            d = b as Derived1;
            if (d != null) // true
                Console.Write("b = new Derived1();\n");

            b = new Derived2();
            d = b as Derived1;
            if (d != null) // false
                Console.Write("b = new Derived2();\n");

            // castに失敗するとエラー
            d = (Derived1)b; // これはエラーとなる(System.InvalidCastException)

            #endregion
        }
    }
}
