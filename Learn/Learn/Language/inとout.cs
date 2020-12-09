using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class inとout
    {
        // https://ufcpp.net/study/csharp/sp_ref.html

        public inとout()
        {
            #region inとout

            Console.WriteLine("inとout\r\n");

            // 参照渡しと値渡しの続き
            // inとoutはC#に用意された特殊な参照渡しの方法
            // refは読み書き可能で、制限を加えることはできないが
            // C# 7.2 から、「参照渡しだけど読み取り専用」が指定可能になった(= in)
            // 主な用途は大きな構造体の処理(値渡しだとコピーが重い)とかに使う
            // 逆に値の割り当て(=書き込み)を強制するのがout
            // 主な用途はメソッドの引数に指定して、多値を返す場合に使う(TryParseとか)
            // 多値を返すことはoutではなくTupleを使っても実現できる

            var sampleClass = new TestClass(1);
            AddOneForTestClassPropertyRewriteRef(ref sampleClass); // メソッド内で書換可能
            Console.WriteLine($"{sampleClass.MyProperty}"); // これは6

            // inは書換されないことを保証してくれるので安心して渡すことができる
            sampleClass = new TestClass(1);
            AddOneForTestClassPropertyRewriteIn(in sampleClass);
            AddOneForTestClassPropertyRewriteIn(sampleClass); // 書換されないことが保証されているので ref と異なり、呼び出し側で in を省略可能

            // 逆に、outでは処理の中で割り当てされることが約束される
            sampleClass = new TestClass(1);
            AddOneForTestClassPropertyRewriteOut(out sampleClass); // 必ずsampleClassはこの処理で書き変わる
            AddOneForTestClassPropertyRewriteOut(out TestClass hoge); // 必ずこの処理で割り当てされるので初期化不要で呼べる
            Console.WriteLine($"{hoge.MyProperty}"); // これは6
            bool isPositiveNumber = JudgeAddOneForTestClassPropertyRewriteOut(out sampleClass); // 主に多値を返す場合に使用する(TryParseとか有名)
            (isPositiveNumber, sampleClass) = JudgeAddOneForTestClassPropertyTuple(sampleClass); // Tupleでも多値を返すことができる

            #endregion
        }

        private void AddOneForTestClassPropertyRewriteRef(ref TestClass testClass)
        {
            var tmp = new TestClass(5);

            // ここで参照先を変更する
            testClass = tmp;
            testClass.MyProperty += 1;
        }

        private void AddOneForTestClassPropertyRewriteIn(in TestClass testClass)
        {
            var tmp = new TestClass(5);

            // testclass = tmp; // inで指定されたパラメータは書換不能
            testClass.MyProperty += 1;
        }

        private void AddOneForTestClassPropertyRewriteOut(out TestClass testClass)
        {
            // outで指定されたパラメータは必ずこの処理の中で割り当てが必要となる
            // ↓これはNG(この処理の中で未割当だから)
            // testclass.MyProperty += 1;

            testClass = new TestClass(5); // 割当
            testClass.MyProperty += 1;
        }

        private bool JudgeAddOneForTestClassPropertyRewriteOut(out TestClass testClass)
        {
            testClass = new TestClass(5); // 割当
            testClass.MyProperty += 1;

            // メソッド本来の返り値(= bool) の他に out で指定した値も返却できる
            return (testClass.MyProperty > 0) ? true : false;
        }

        private (bool , TestClass) JudgeAddOneForTestClassPropertyTuple(TestClass testClass)
        {
            testClass = new TestClass(5); // 割当
            testClass.MyProperty += 1;
            bool isPositiveNumber = (testClass.MyProperty > 0) ? true : false;

            // メソッド本来の返り値(= bool) の他に out で指定した値も返却できる
            return (isPositiveNumber, testClass);
        }

        private class TestClass
        {
            /// <summary>
            /// 値型のプロパティ
            /// </summary>
            public int MyProperty { get; set; }

            public TestClass(int x) => MyProperty = x;
        }
    }
}
