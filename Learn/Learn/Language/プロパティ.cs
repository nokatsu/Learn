using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class プロパティ
    {
        // https://ufcpp.net/study/csharp/oo_property.html

        // プロパティは
        // クラス外部から見るとメンバー変数のように振る舞い、 クラス内部から見るとメソッドのように振舞うもの


        // 古き良きプロパティの書き方
        private double myProperty; // こいつは公開せず隠匿する
        public double MyProperty
        {
            set { this.myProperty = value; }
            get { return this.myProperty; }
        }

        // 今時の楽な書き方
        public double MyProperty2 { get; set; }

        // Getterのみも可能
        public double MyProperty3 { get; }

        // GetterとSetterで異なるアクセスレベルも設定可能
        public double MyProperty4 { get; private set; }

        // 初期化もOK
        public double MyProperty5 { get; set; } = 1.23;

        public プロパティ()
        {
            #region プロパティ

            Console.WriteLine("プロパティ\r\n");

            // プロパティ
           
            #endregion
        }
    }
}
