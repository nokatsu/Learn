using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{ 
    // https://takap-tech.com/entry/2016/07/25/190835
    // https://ufcpp.net/study/csharp/sp_event.html

    public class イベント
    {
        // イベントはdelegate専用のプロパティ
        // 自クラスではdelegateのようにふるまい
        // 利用側では、メソッドの登録と登録解除しかできないようにふるまう

        public イベント(DelegateEvent source)
        {
            Console.WriteLine("\r\nイベント\r\n");


            // 普通のdelegateプロパティだとなんでもできちゃう

            // 自分のメソッドを設定
            source.PropDelegate = this.AnHandler;
            // 自分のメソッドを追加
            source.PropDelegate += this.AnHandler;
            // 登録内容を全部削除
            source.PropDelegate = null;
            // デリゲートを呼び出す(この場合は例外)    
            source.PropDelegate(this, new EventArgs());



            // イベントの操作

            // 自分のメソッドを設定
            //source.HogeEvent = this.AnHandler; // ★「できない
            // 自分のメソッドを追加
            source.HogeEvent += this.AnHandler;
            // 登録内容を全部削除
            //source.HogeEvent = null; // ★できない
            // 自分が登録した内容を解除
            source.HogeEvent -= this.AnHandler;
            // デリゲートを呼び出す(この場合は例外)    
            //source.HogeEvent(this, new EventArgs()); // ★できない

        }

        // デリゲートやイベントに設定するメソッド
        public void AnHandler(object sender, EventArgs e) 
        {
            // なんか処理
        }
    }

    public class DelegateEvent
    {
        // 普通のプロパティで公開する（自動実装）
        public Action<object, EventArgs> PropDelegate { get; set; }

        // event構文で公開する（自動実装）
        public event Action<object, EventArgs> HogeEvent;
    }
}
