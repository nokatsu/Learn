using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
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

            #endregion
        }
    }
}
