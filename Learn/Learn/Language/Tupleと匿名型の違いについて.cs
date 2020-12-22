using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // https://ufcpp.net/study/csharp/structured/st_anonymoustype/

    class Tupleと匿名型の違いについて

    {
        public Tupleと匿名型の違いについて()
        {
            #region Tupleと匿名型の違いについて

            Console.WriteLine("\r\nTupleと匿名型について\r\n");

            var tuple = (x: 10, y: 20); // tuple
            var anonymousType = new { x = 10, y = 20 }; // 匿名型

            // Setterの有無(tupleは値型だが…)
            tuple.x = 20; // OK
            //anonymousType.x = 20; // NG: setterがない


            // 使い分けとしては…
            // Tupleは関数で多値を返す場合に使う
            // 匿名型はLinq等でクラスの中から部分的にメンバを抜き出す場合に使う
            var persons = new[] {
                new X(1, "1さん", 31),
                new X(2, "2さん", 50),
                new X(3, "3さん", 11),
                new X(4, "4さん", 23),
                new X(5, "5さん", 33),
                new X(6, "6さん", 54),
            };

            var histgram = persons
                .GroupBy(p => new { p.Id, AgeDecade = p.Age / 10 }) // ここで匿名型(Linq途中の型に意味などないので、名称を付けたくない)
                .Select(g => new { g.Key.Id, g.Key.AgeDecade, Count = g.Count() }) // ここでも匿名型
                .OrderBy(x => x.AgeDecade)
                .ThenBy(x => x.Id);

            #endregion
        }

        private class X
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public X(int id, string name, int age) => (Id, Name, Age) = (id, name, age);
        }
    }
}
