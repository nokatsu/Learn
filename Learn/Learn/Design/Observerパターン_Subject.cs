//using System;
//using System.Collections.Generic;
//using System.Reactive.Subjects;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Learn.Design
//{
//    // https://blog.xin9le.net/entry/2011/12/19/025912

//    public class Observerパターン_Subject
//    {
//        // .Netでは、オブザーバパターン実装を簡素化するためにSystem.Reactiveが存在する
//        // Subject では、IObservable<T> と IObserver<T>の両方を実装し、
//        // ここに実装した場合と比べ、はるかに簡単にオブザーバパターンを実現できる

//        public Observerパターン_Subject()
//        {
//            var subject = new Subject<Data>();
//            var disposerA = subject.SubscribeTracer("A");
//            subject.OnNext(1);
//            var disposerB = subject.SubscribeTracer("B");
//            subject.OnNext(2);
//            disposerA.DisposeTracer("A");
//            subject.OnNext(3);
//            subject.OnCompleted();
//            var disposerC = subject.SubscribeTracer("C");
//            subject.OnNext(4);
//        }






//        /// <summary>
//        /// データのモデルクラス
//        /// </summary>
//        private class Data
//        {
//            public int Data1 { get; set; }
//            public int Data2 { get; set; }
//            public List<int> Data3 { get; set; }

//            public Data(int data1, int data2, List<int> data3) => (Data1, Data2, Data3) = (data1, data2, data3);
//        }

//        #region Interfaceの実装

//        private IDisposable SubscribeTracer<T>(this IObservable<T> source, string name)
//        {
//            var disposer = source.Subscribe
//            (
//                value => Console.WriteLine("{0} : OnNext({1})", name, value),
//                () => Console.WriteLine("{0} : OnCompleted", name)
//            );
//            return disposer;
//        }

//        private void DisposeTracer(this IDisposable source, string name)
//        {
//            source.Dispose();
//        }

//        #endregion
//    }
//}
