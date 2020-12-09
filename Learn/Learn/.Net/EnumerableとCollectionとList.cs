using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Net
{
    class EnumerableとCollectionとList
    {
        // https://ufcpp.net/study/csharp/oo_interface.html?p=2
        // https://qiita.com/lobin-z0x50/items/248db6d0629c7abe47dd

        public EnumerableとCollectionとList()
        {
            Console.WriteLine("EnumerableとCollectionとList\r\n");

            // IEnumerable<T>           : 要素の列挙ができる。foreachステートメントや、LINQ to Objects で使える。
            // ICollection<T>           : IEnumerable<T>に加えて、要素の追加(Add)、削除(Remove)などができたり、要素の個数が取れる。
            // IList<T>                 : ICollection<T>に加えて、インデクサーを使った要素の読み書きができる。(要は順序がある)
            // IReadOnlyCollection<T>   : IEnumerable<T>に加えて、要素の個数が取れる。読み取り専用なので共変。
            // IReadOnlyList<T>         : IReadOnlyCollection<T>に加えて、インデクサーを使った要素の読み取りができる。読み取り専用なので共変。
            // List<T>                  : IList<T>の実装 + Sort(), Reverse(), Contain()等のお便利メソッドを実装している
            // ReadOnlyCollection<T>    : 実質 ReadOnlyList。こいつもIList<T>を実装している
            // ReadOnlyList<T>          : 存在しない

            List<string> list = new List<string> { "hoge", "fuga", "piyo" };

            IEnumerable<string> enumeratableList = list.AsEnumerable(); // IEnumerableはAsEnumerable()で生成可能
            ReadOnlyCollection<string> readonlyList = list.AsReadOnly(); // ReadOnlyCollectionはAsReadOnly()で生成可能

            var result1 = RemoveUnnecessary(list as IReadOnlyCollection<string>); // 共変
            var result2 = RemoveUnnecessary(list.AsReadOnly());
            var result3 = RemoveUnnecessary(new string[] { "hoge", "fuga", "piyo" }); // 配列も渡せる(一時配列はIListやIReadOnlyListを実装している) 

            RemoveUnnecessary(list);
        }

        /// <summary>
        /// これなら、引数のentitiesは変更されないことがわかる
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        private List<string> RemoveUnnecessary(IReadOnlyCollection<string> entities)
        {
            List<string> list = new List<string>();

            foreach(var item in entities)
            {
                if(item != "piyo")
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// これなら、引数のentitiesは更新されることがわかる
        /// </summary>
        /// <param name="entities"></param>
        private void RemoveUnnecessary(List<string> entities)
        {
            entities.Remove("piyo");
        }
    }
}
