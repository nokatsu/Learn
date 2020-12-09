using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class 参照渡しと値渡し
    {
        // https://ufcpp.net/study/csharp/sp_ref.html

        public 参照渡しと値渡し()
        {
            #region 参照渡しと値渡し

            Console.WriteLine("参照渡しと値渡し\r\n");

            // C#のオブジェクトには値型と参照型が存在するが
            // オブジェクトの受け渡し方法も値渡しと参照渡しが存在する
            // よって、C#では2 * 2のバリエーションが存在する(値型の参照渡し, 参照型の値渡し, …)
            // 参照型の参照渡しはほぼ利用パターンがないが一応説明する

            // 値の受け渡しシチュエーションは大きく分けて３パターンある

            // ①変数から変数(「値型と参照型」を参照)
            int sampleInt = 1;
            int testInt = sampleInt; // これ

            // ②変数から引数
            AddOne(sampleInt);

            // ③戻り値から変数
            sampleInt = ReturnOne();

            // そして、渡し方は２種類ある
            // 値渡し： メソッド内で引数の値を書きかえても、呼び出し元には影響しない。
            // 参照渡し（ref）： メソッド内での値の書き換えの影響が呼び出し元に伝搬する。
            // C#では普通に書くと値渡しになる(↑の例はすべて値渡し)
            // なので…
            sampleInt = 1;
            AddOne(sampleInt);
            Console.WriteLine($"{sampleInt}"); // これは2にならない(値型の値渡しであるため、コピーが生成される)

            var sampleClass = new TestClass(1);
            AddOneForTestClassProperty(sampleClass);
            Console.WriteLine($"{sampleClass.MyProperty}"); // これは2になる(参照型の値渡し)
            // 紛らわしいが、参照情報は値渡しされているのでコピーされている。値渡しされた段階では、二つとも参照先は一緒
            // なので、呼び出し先で参照情報を変更すれば元の値は影響を受けなくなる
            sampleClass = new TestClass(1);
            AddOneForTestClassPropertyRewriteRef(sampleClass);
            Console.WriteLine($"{sampleClass.MyProperty}"); // これは1になる(6じゃない)

            // 参照渡しをするためにはrefキーワードを用いる
            sampleInt = 1;
            AddOne(ref sampleInt); // 呼び出し元、呼び出し先の両方にrefをつける必要がある
            Console.WriteLine($"{sampleInt}"); // これは2になる(値型の参照渡しであるため、コピーが生成されない)

            // これはほとんどないが参照型の参照渡しも可能
            sampleClass = new TestClass(1);
            AddOneForTestClassPropertyRewriteRef(ref sampleClass);
            Console.WriteLine($"{sampleClass.MyProperty}"); // これは6になる(参照渡しなので参照情報はコピーではなく同一のポインタを持つ)





            // また、ローカル変数に対しても、ref修飾子を付けることで参照渡しができる。
            var a = 10;
            ref var b = ref a; // 参照ローカル変数。宣言側にも、値を渡す側にも ref

            var c = b;         // これは普通に値渡し(コピー)。この時点の a の値 = 10 が入る
            ref var d = ref b; // さらに参照渡しで、結局 a を参照

            d = 1; // d = b = a を書き換え

            ref var e = ref Ref(ref c); // 参照戻り値越しに、c を参照
            var f = Ref(ref c);         // これは結局、値渡し(コピー)

            ++e;   // e = c を +1。元が10なので、11に
            f = 0; // f は普通に値渡しで作った新しい変数なので他に影響なし

            // 結果は 1, 1, 11, 1, 11, 0
            // a, b, d が同じ場所を参照してて 1
            // 同上、c, e が 11
            // f が 0
            Console.WriteLine(string.Join(", ", a, b, c, d, e, f));


            #endregion
        }

        private void AddOne(int num)
        {
            num += 1;
        }

        /// <summary>
        /// refの有無でoverload可能なのだ！
        /// </summary>
        /// <param name="num"></param>
        private void AddOne(ref int num)
        {
            num += 1;
        }

        private int ReturnOne() => 1;

        private void AddOneForTestClassProperty(TestClass testclass)
        {
            testclass.MyProperty += 1;
        }

        private void AddOneForTestClassPropertyRewriteRef(TestClass testclass)
        {
            var tmp = new TestClass(5);

            // ここで参照先を変更する
            testclass = tmp;
            testclass.MyProperty += 1;
        }

        /// <summary>
        /// refの有無でoverload可能なのだ！
        /// </summary>
        private void AddOneForTestClassPropertyRewriteRef(ref TestClass testclass)
        {
            var tmp = new TestClass(5);

            // ここで参照先を変更する
            testclass = tmp;
            testclass.MyProperty += 1;
        }

        private class TestClass
        {
            /// <summary>
            /// 値型のプロパティ
            /// </summary>
            public int MyProperty { get; set; }

            public TestClass(int x) => MyProperty = x;
        }

        static ref int Ref(ref int x) => ref x;
    }
}
