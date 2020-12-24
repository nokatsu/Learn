using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // https://rksoftware.hatenablog.com/entry/2020/11/21/204039
    class initセッター
    {
        // C# 9 から！

        // プロパティのsetterの代わりに指定可能
        // 初期化のタイミングでのみ、set可能で以後readonlyとなる
        // つまり、immutableな値とすることができる
        
        public initセッター()
        {
            Console.WriteLine("\r\ninitセッター\r\n");

            var init = new InitClass(1);
            //init.Num = 0; // NG
            init.AddNums(100); // これはできちゃうので注意！

            var privateSetter = new PrivateSetterClass(1);
            //privateSetter.Num = 0; // これはNGにできるが…
            privateSetter.Change(0); // これで変更できちゃう

            var getterOnlyClass = new GetterOnlyClass(1);
            //getterOnlyClass.Num = 0; // NG

            var readOnlyClass = new ReadOnlyClass(1);
            //readOnlyClass.Num = 0; // NG
        }

        private class InitClass
        {
            public int Num { get; init; }
            public List<int> Nums { get; init; } = new List<int> { 1, 2 };
            public IReadOnlyCollection<int> NumsReadOnly { get; init; } = new List<int> { 1, 2 }.AsReadOnly();

            public InitClass(int num) => Num = num;

            // これはreadonlyなのでNG
            //public void Change(int num) => Num = num;
            
            // 書換を防止できるだけで、普通にプロパティの変更はできちゃうので
            public void AddNums(int num) => Nums.Add(num);
            // 適切なアクセシビリティを設定して防ぐ必要があるね
            // public void AddNumsReadOnly(int num) => NumsReadOnly.Add(num);
        }

        private class PrivateSetterClass
        {
            public int Num { get; private set; }

            public PrivateSetterClass(int num) => Num = num;

            // これはできちゃう…
            // immutableじゃなくなっちゃう
            public void Change(int num) => Num = num;
        }

        private class GetterOnlyClass
        {
            public int Num { get; }

            public GetterOnlyClass(int num) => Num = num;

            // これはSetterがないのでNG
            //public void Change(int num) => Num = num;
        }

        private class ReadOnlyClass
        {
            public readonly int _Num;
            public int Num
            {
                get { return this._Num; }
            }

            public ReadOnlyClass(int num) => _Num = num;

            // これはreadonlyなのでNG
            //public void Change(int num) => _Num = num;
        }
    }
}
