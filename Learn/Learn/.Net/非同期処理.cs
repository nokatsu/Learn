using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learn.Net
{
    // https://qiita.com/rawr/items/5d49960a4e4d3823722f
    // https://qiita.com/acple@github/items/8f63aacb13de9954c5da
    // https://qwerty2501.hatenablog.com/entry/2014/04/24/235849

    public class 非同期処理
    {
        private 非同期処理()
        {
            // 「コンストラクタで非同期メソッドを呼ぶ」参照
        }

        public static async Task<非同期処理> Create()
        {
            Console.WriteLine("\r\n非同期処理\r\n");

            非同期処理 myClass = new 非同期処理();

            Console.WriteLine("同期処理");
            myClass.RunHeavyMethodSync();

            Console.WriteLine("非同期処理");
            await myClass.RunHeavyMethodParallel2();

            return myClass;
        }



        private void HeavyMethod(int x)
        {
            Thread.Sleep(10 * (100 - x)); // てきとーに時間を潰す
            Console.WriteLine(x);
        }



        /// <summary>
        /// 比較のため、ただの同期メソッド
        /// </summary>
        public void RunHeavyMethodSync() // 
        {
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                HeavyMethod(x);
            }
        }



        /// <summary>
        /// 非同期メソッドだが順次動作
        /// </summary>
        /// <returns></returns>
        public async Task RunHeavyMethodAsync1()
        {
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                await Task.Run(() => HeavyMethod(x)); // 「HeavyMethodを実行する」というタスクを開始し、完了するまで待機を、10回繰り返す
            }
        } // というタスクを表すので、これは順次動作であり、並列ではない。



        /// <summary>
        /// 動作はRunHeavyMethodAsync1と同じだけど、HeavyMethodの実行がいつ完了するのか知ることができない。つらい。
        /// </summary>
        public async void RunHeavyMethodAsync2() // RunHeavyMethodAsync1の戻り値がvoidになっただけ
        {
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                await Task.Run(() => HeavyMethod(x));
            }
        }



        /// <summary>
        /// Task.Runが投げっぱなしなので、HeavyMethodの状態がわからなくてつらい。
        /// </summary>
        public void RunHeavyMethodParallel1() // asyncじゃない
        {
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                Task.Run(() => HeavyMethod(x)); // HeavyMethodを開始せよという命令
            } // を、10回繰り返すだけなので、これは並列動作になる。
        }



        /// <summary>
        /// 非同期メソッドではないが、戻り値がTaskなので、このメソッドは一つのタスクを表しているといえる。
        /// </summary>
        /// <returns></returns>
        public Task RunHeavyMethodParallel2() // asyncじゃないけど、戻り値がTask
        {
            var tasks = new List<Task>(); // TaskをまとめるListを作成
            for (var i = 0; i < 10; i++)
            {
                var x = i;
                var task = Task.Run(() => HeavyMethod(x)); // HeavyMethodを開始するというTask
                tasks.Add(task); // を、Listにまとめる
            }
            return Task.WhenAll(tasks); // 全てのTaskが完了した時に完了扱いになるたった一つのTaskを作成
        }

    }
}
