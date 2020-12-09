using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Net
{
    class IEnumeratorとIEnumerable
    {
        // https://qiita.com/vc_kusuha/items/2048391d821cb94fa489
        // https://smdn.jp/programming/netfx/enumerator/0_enumerable_enumerator/

        public IEnumeratorとIEnumerable()
        {
            Console.WriteLine("IEnumeratorとIEnumerable\r\n");

            // IEnumerableといえばLINQ
            // IEnumerableを実装していれば、超便利なforeachが使える
            // しかし、System.Collectionsには、IEnumerableの他にIEnumeratorもある
            // 何が何やらの時のためのページ




            // IEnumeratorはSystem.Collections 名前空間内にあり、以下の要素を実装する
            // bool MoveNext();
            // void Reset(); ←自前で実装する場合には、これは実際には実装不要らしい、Exceptionを投げるようにしておけばいい
            // object Current; ←MoveNextでfalseが返った後の挙動はInterfaceでは不定、なるべくそれに依存したロジックは書かないこと

            // IEnumerable は反復処理をサポートする列挙子(つまり IEnumerator )を公開するインターフェース。
            // こちらも System.Collections 名前空間内にあり、 IEnumerator を返す GetEnumerator 関数を持つことが保証される。
            IEnumerable<string> sample = new string[] { "hoge", "fuga", "piyo" }; // 実は一時配列はIListを実装している
            var enumerator = sample.GetEnumerator();

            // MoveNext() でイテレータを次に進ませて、 Current でその値を取得。 Reset() を呼び出すとイテレータを初期位置に戻す。
            // MoveNext() の返り値は bool だが、これはイテレータを進ませることができた場合に true が返る。
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            // IEnumerable インターフェースを実装していると、 foreach を用いて反復処理を行うことができる。
            foreach (var item in sample)
            {
                Console.WriteLine(item);
            }

            // IEnumeratableを実装していないのでIEnumeratorを実装していてもforeachは使えない
            // foreach (var item in enumerator) { }; // ←NG
        }
    }
}
