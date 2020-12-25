using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // https://ufcpp.net/study/csharp/sp_delegate.html
    // http://once-and-only.com/programing/c/delegate%E3%81%A8action%E3%81%A8event%EF%BC%88c-wpf%EF%BC%89/

    public class デリゲート
    {
        // デリゲートとはメソッドを参照するための型
        // メソッドを変数的に扱うことができる
        // イベント等、幅広く利用される

        // intを引数に受ける返り値voidの SomeDelegate という名前のデリゲート型を定義
        delegate void SomeDelegate(int a);

        public デリゲート()
        {
            Console.WriteLine("\r\nデリゲート\r\n");

            SomeDelegate sampleDeligate = A; // 暗黙にSomeDelegate型に変換
            sampleDeligate += B; // 複数のメソッドを追加可能
            sampleDeligate += (int n) => { Console.Write("C({0}) が呼ばれました。\n", n); }; // ラムダ式もOK
            sampleDeligate += n => { Console.Write("D({0}) が呼ばれました。\n", n); }; // 型推論できれば引数の型は省略可能
            sampleDeligate += n => Console.Write("E({0}) が呼ばれました。\n", n); // 内容が単一行なら{}も省略可能

            sampleDeligate(256);
        }


        private void A(int n)
        {
            Console.Write("A({0}) が呼ばれました。\n", n);
        }
        private void B(int n)
        {
            Console.Write("B({0}) が呼ばれました。\n", n);
        }
    }
}
