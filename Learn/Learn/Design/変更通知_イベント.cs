using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Design
{
    // https://zenn.dev/yutori/articles/be374b10621b83e4f77d
    
    public class 変更通知_イベント
    {
        // クラス間の変更通知
        // あるクラス(DataServerクラス)が持つデータの変更を
        // 即時に他のクラス(DataViewクラス)で検知したい

        public 変更通知_イベント()
        {
            DataServer server = new DataServer();
            DataReceiver view = new DataReceiver(server);

            server.Data1 = 1;
            server.Data2 = 2;
            server.Data3 = new List<int> { 1, 2 };
            server.Data3.Add(2); // これはSetterを経由しないのでイベントが発火しない

            // viewが増えても問題なし！
            DataReceiver view2 = new DataReceiver(server);
            DataReceiver view3 = new DataReceiver(server);
            DataReceiver view4 = new DataReceiver(server);
            DataReceiver view5 = new DataReceiver(server);
            DataReceiver view6 = new DataReceiver(server);

            server.Data1 = 1;
            server.Data2 = 2;
            server.Data3 = new List<int> { 1, 2 };
        }

        /// <summary>
        /// データを保持するクラス
        /// </summary>
        private class DataServer
        {
            // viewに変更を通知するためのイベント
            public event Action<int> Data1Changed;
            public event Action<int> Data2Changed;
            public event Action<List<int>> Data3Changed;

            private int _data1;
            public int Data1
            {
                get => _data1;
                set
                {
                    _data1 = value;
                    Data1Changed?.Invoke(value);
                }
            }

            private int _data2;
            public int Data2
            {
                get => _data2;
                set
                {
                    _data2 = value;
                    Data2Changed?.Invoke(value);
                }
            }

            private List<int> _data3;
            public List<int> Data3
            {
                get => _data3;
                set
                {
                    _data3 = value;
                    Data3Changed?.Invoke(value);
                }
            }
        }

        /// <summary>
        /// Dataを受け取りたいクラス
        /// </summary>
        private class DataReceiver
        {
            public DataReceiver(DataServer server)
            {
                // serverで発火したイベントに自身の処理を追加する
                server.Data1Changed += this.Data1Changed;
                server.Data2Changed += this.Data2Changed;
                server.Data3Changed += this.Data3Changed;
            }

            private void Data1Changed(int data1)
            {
                Console.WriteLine("Data1 is Changed !");
            }
            private void Data2Changed(int data2)
            {
                Console.WriteLine("Data2 is Changed !");
            }
            private void Data3Changed(List<int> data3)
            {
                Console.WriteLine("Data3 is Changed !");
            }
        }
    }
}
