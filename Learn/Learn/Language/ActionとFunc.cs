using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // http://once-and-only.com/programing/c/delegate%E3%81%A8action%E3%81%A8event%EF%BC%88c-wpf%EF%BC%89/

    public class ActionとFunc
    {
        // Action と Func (と Predicate) はC#で事前定義されているdeligateのこと
        // Actionは返り値がvoidのdeligate
        // Funcは返り値を持つdeligate
        // Predicateは返り値がboolのdelegate(あんまり使わないけど…)


        // この２つは同じ意味
        delegate void SomeDelegate(int a);
        Action<int> SomeAction;

        // この２つも同じ意味
        delegate string SomeDelegate2(int a);
        Func<int, string> SomeFunc; // 返り値を<>内の最後に指定

        // 複数の引数に対応可能
        delegate void SomeDelegate3(int a, int b);
        Action<int, int> SomeActionMultiParameter;

        public ActionとFunc()
        {
            Console.WriteLine("\r\nActionとFunc\r\n");

            // めんどくさいdelegateの宣言を省略できる
            SomeAction = A;
            SomeAction += B; // 複数のメソッドを追加可能
            SomeFunc += C;
            SomeFunc += n => $"D Called {n}";
            SomeActionMultiParameter += (n, m) => Console.Write("E({0}, {1}) が呼ばれました。\n", n, m);

            SomeAction(256);
            string hoge =SomeFunc(256);
            Console.WriteLine($"SomeFunc: {hoge}"); // Cメソッドの返り値は拾われない
            SomeActionMultiParameter(256, 512);

            Predicate<int> pred = n => n > 100;
            hoge = pred(50) ? "bigeer than 100" : "smaller than 100";
            Console.WriteLine($"pred called 50:  {hoge}");
        }

        private void A(int n)
        {
            Console.Write("A({0}) が呼ばれました。\n", n);
        }
        private void B(int n)
        {
            Console.Write("B({0}) が呼ばれました。\n", n);
        }
        private string C(int n)
        {
            Console.Write("C({0}) が呼ばれました。\n", n);
            return "C";
        }
    }
}
