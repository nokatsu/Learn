using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    class Tupleのrefについて
    {
        public Tupleのrefについて()
        {
            #region Tupleのrefについて

            Console.WriteLine("Tupleのrefについて\r\n");

            // タプルのフィールド(≠メンバ)はref可能なことを検証する
            var result = (x: 10, y: 20);


            // これは値渡しなので書き変わらない
            TestSwap<int>.Swap(result.x, result.y);
            Console.WriteLine($"Tuple(値型)の値渡し: {result}");


            // これは参照渡しなので書き変わる
            TestSwap<int>.SwapRef(ref result.x, ref result.y);
            Console.WriteLine($"Tuple(値型)の参照渡し: {result}");


            // 分解(値渡し)
            result = (10, 20); // リセット
            var (x2, y2) = result; // タプルは値型なのだ(匿名クラスはクラスなので参照渡し)

            // 分解した時点で値渡しとなるため、その後のスワップは影響しない
            TestSwap<int>.SwapRef(ref result.x, ref result.y);
            Console.WriteLine($"Tuple(値型)を分解(値渡し)し、値渡し: ({x2}, {y2})");


            // 分解(参照渡し)
            result = (10, 20); // リセット
            ref var x3 = ref result.x;
            ref var y3 = ref result.y;
            //ref var (x3, y3) = ref result; // これはNG
            //(ref var x3, ref var y3) = ref result; // これもNG

            // 分解した時点で参照渡しすれば、当然スワップは影響する
            TestSwap<int>.SwapRef(ref result.x, ref result.y);
            Console.WriteLine($"Tuple(値型)を分解(参照渡し)し、参照渡し：({x3}, {y3})");

            #endregion
        }
    }

    static class TestSwap<T>
    {
        /// <summary>
        /// 値渡しのため、機能しないゴミメソッド
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Swap(T x, T y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }

        /// <summary>
        /// 参照渡しのため、機能する本来のスワップメソッド
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SwapRef(ref T x, ref T y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }
    }
}
