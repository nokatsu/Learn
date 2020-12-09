using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class 値型と参照型
    {
        // https://ufcpp.net/study/csharp/oo_reference.html

        public 値型と参照型()
        {
            #region 値型と参照型

            Console.WriteLine("値型と参照型\r\n");

            // C#のオブジェクトには値型と参照型が存在する
            // 値型: 変数に直接値が格納される
            // 参照型: 変数が持っているのは参照情報（実体がどこにあるのかという情報）だけ。実体は別の場所に確保される

            // 値型は代入時に複製が生じる
            // 参照型は代入時に値は複製しない

            // 組み込み型では…
            // int, double, bool, enum 等は値型
            // string, 配列, object等は参照型
            int sampleInt = 1;
            List<int> sampleList = new List<int>{ 1 };

            int testInt = sampleInt; // intは値型なのでコピーが作成される
            List<int>testList = sampleList; // Listは参照型なのでコピーは作成されない(Listや配列の内部の方が値型であっても関係ない)

            testInt = 2; // コピーなので、もとの値(sampleInt)は影響ない
            testList[0] = 2; // もとの値を参照しているだけなので代入によってsampleList[0]の中身も変更される

            Console.WriteLine($"{sampleInt}, {testInt}");
            Console.WriteLine($"{sampleList[0]}, {testList[0]}");

            // Structは値型
            // Class, Interface, Deligateは参照型
            var sampleClass = new TestClass(1);
            var sampleStruct = new TestStruct(1);

            var testClass = sampleClass;
            var testStruct = sampleStruct;

            testClass.MyProperty = 2;
            testStruct.MyPropety = 2;

            Console.WriteLine($"{sampleClass.MyProperty}, {testClass.MyProperty}");
            Console.WriteLine($"{sampleStruct.MyPropety}, {testStruct.MyPropety}");

            #endregion
        }

        private class TestClass
        {
            /// <summary>
            /// 値型のプロパティ
            /// </summary>
            public int MyProperty { get; set; }

            public TestClass(int x) => MyProperty = x;
        }

        private struct TestStruct
        {
            /// <summary>
            /// 値型のプロパティ
            /// </summary>
            public int MyPropety { get; set; }

            public TestStruct(int x) => MyPropety = x;
        }
    }
}
