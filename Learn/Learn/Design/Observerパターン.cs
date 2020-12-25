using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Design
{
    // https://zenn.dev/yutori/articles/be374b10621b83e4f77d
    // https://blog.xin9le.net/entry/2011/12/10/153032

    public class Observerパターン
    {
        // .Netでは、オブザーバパターン実装のためのInterfaceが用意されている
        // IObservable<T>   : 監視対象のインターフェース。Subscribeメソッドのみを持つ。戻り値はIDisposableで配信の停止を実装する。
        // IObserver<T>     : 観測者のインターフェース。OnNext, OnError, OnCompleteの3つのメソッドを持つ。

        public Observerパターン()
        {
            var provider = new DataServer();
            var unsbscriber1 = provider.Subscribe(new DataReceiver("川口"));
            var unsbscriber2 = provider.Subscribe(new DataReceiver("椿原"));
            var unsbscriber3 = provider.Subscribe(new DataReceiver("桑原"));

            provider.Deliver(new Data(1, 10, new List<int> { 100, 1000 }));
            unsbscriber1.Dispose();
            provider.Deliver(null);
            provider.Deliver(new Data(2, 20, new List<int> { 200, 2000 }));
            unsbscriber2.Dispose();
            provider.StopDelivering();
            provider.Deliver(new Data(3, 30, new List<int> { 300, 3000 }));
            unsbscriber3.Dispose();
        }






        /// <summary>
        /// データのモデルクラス
        /// </summary>
        private class Data
        {
            public int Data1 { get; set; }
            public int Data2 { get; set; }
            public List<int> Data3 { get; set; }

            public Data(int data1, int data2, List<int> data3) => (Data1, Data2, Data3) = (data1, data2, data3);
        }

        #region Interfaceの実装

        #region IObservable(監視対象)の実装
        private class DataServer : IObservable<Data>
        {
            /// <summary>
            /// 観測者のコレクションを保持します。
            /// </summary>
            private readonly LinkedList<IObserver<Data>> observers = new LinkedList<IObserver<Data>>();

            /// <summary>
            /// 観測者が通知を受け取ることをプロバイダーに通知します。
            /// </summary>
            public IDisposable Subscribe(IObserver<Data> observer)
            {
                if (!this.observers.Contains(observer))
                    this.observers.AddLast(observer);
                return new Unsbscriber(this.observers, observer);
            }

            /// <summary>
            /// 配信します。
            /// </summary>
            public void Deliver(Data news)
            {
                foreach (var observer in this.observers)
                {
                    if (news == null) observer.OnError(new ArgumentNullException());
                    else observer.OnNext(news);
                }
            }

            /// <summary>
            /// 配信を終了します。
            /// </summary>
            public void StopDelivering()
            {
                foreach (var observer in this.observers)
                    observer.OnCompleted();
                this.observers.Clear();
            }

            /// <summary>
            /// 購読を解除する機能を提供します。
            /// </summary>
            private class Unsbscriber : IDisposable
            {
                private readonly LinkedList<IObserver<Data>> observers = null;
                private readonly IObserver<Data> observer = null;

                public Unsbscriber(LinkedList<IObserver<Data>> observers, IObserver<Data> observer)
                {
                    this.observers = observers;
                    this.observer = observer;
                }

                /// <summary>
                /// 使用していたリソースを解放します。
                /// </summary>
                public void Dispose()
                {
                    if (this.observers.Contains(this.observer))
                        this.observers.Remove(this.observer);
                }
            }
        }
        #endregion

        #region IObserver(観測者)の実装
        private class DataReceiver : IObserver<Data>
        {
            /// <summary>
            /// 受信者名を取得します。
            /// </summary>
            public string Name { get; private set; }

            public DataReceiver(string name)
            {
                this.Name = name;
            }

            /// <summary>
            /// プロバイダーがプッシュベースの通知の送信を完了したことをオブザーバーに通知します。
            /// </summary>
            public void OnCompleted()
            {
                Console.WriteLine("{0} : OnCompleted", this.Name);
            }

            /// <summary>
            /// プロバイダーでエラー状態が発生したことをオブザーバーに通知します。
            /// </summary>
            public void OnError(Exception error)
            {
                Console.WriteLine("{0} : OnError", this.Name);
            }

            /// <summary>
            /// オブザーバーに新しいデータを提供します。
            /// </summary>
            public void OnNext(Data value)
            {
                Console.WriteLine("{0} : OnNext [{1} - {2} - {3}]", this.Name, value.Data1, value.Data2, value.Data3);
            }
        }
        #endregion

        #endregion
    }
}
