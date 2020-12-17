using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class switch拡張
    {
        // https://ufcpp.net/study/csharp/datatype/typeswitch/?p=2

        public switch拡張()
        {
            #region switch拡張

            Console.WriteLine("switch拡張\r\n");

            // C# 7.0 からSwitch構文が拡張されて型スイッチが使えるようになった

            object obj = "hoge";

            switch (obj)
            {
                // 型パターン
                case string s:
                    Console.WriteLine("string #" + s.Length);
                    break;
                // 定数パターン
                case 7:
                    Console.WriteLine("7の時だけここに来る");
                    break;
                // 型パターン + 条件
                case int n when n > 0:
                    Console.WriteLine("正の数の時にここに来る " + n);
                    // ただし、上から順に判定するので、7 の時には来なくなる
                    break;
                case int n:
                    Console.WriteLine("整数の時にここに来る" + n);
                    // 同上、0 以下の時にしか来ない
                    break;
                case var n:
                    // nullの場合もここに落ちるので注意！
                    Console.WriteLine("これはdefaultと等価" + n);
                    break;
                // あるいは、変数で受け取る必要がないときは _ にしておけば破棄の意味なる
                //case var _: break;

                //default:
                //    Console.WriteLine("その他");
                //    break;
            }

            // Switch構文は上の条件から逐次判定されていく(defaultはどこに書こうが一番最後)
            // シビアな環境では処理速度に影響するので、可能性の高い順に記述することを推奨

            // また、変数代入をswitchの結果で制御するような場合
            // 下記のような書き方も可能になった
            obj = "hoge";
            //obj = -1;
            string str = obj switch
            {
                0 => "Zero",
                1 => "One",
                2 => "Two",
                3 => "Three",
                int x when x > 3 || x < 0 => "Other",
                _ => "not int",
            };

            Console.WriteLine(str);

            #endregion
        }
    }
}
