using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Design
{
    // https://qiita.com/shoheiyokoyama/items/c16fd547a77773c0ccc1
    // https://qiita.com/rohinomiya/items/6bca22211d1bddf581c4

    class Singletonパターン
    {
        // 生成するインスタンスの数を1つに制限するデザインパターン
        // 指定したクラスのインスタンスが1つしか存在しないことを保証する
        // インスタンスが1個しか存在しないことをプログラム上で表現したい

        public Singletonパターン()
        {
            Console.WriteLine("\r\nSingletonパターン\r\n");

            // シングルトンはnew出来ず、GetInstance()経由で使用する
            var target1 = SingletonClass.GetInstance();
            var target2 = SingletonClass.GetInstance();

            if(target1 == target2)
            {
                Console.WriteLine("一緒のインスタンス");
            }

            Console.WriteLine(target1.SingletonProperty);
            
            // ↓NG
            //var ng = new SingletonClass();
        }
    }

    // Singletonパターン
    public sealed class SingletonClass
    {
        public string SingletonProperty { get; }


        private static SingletonClass _singleInstance = new SingletonClass();

        public static SingletonClass GetInstance()
        {
            return _singleInstance;
        }

        private SingletonClass()
        {
            SingletonProperty = "Set by Constractor";
        }
    }
}
