using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Tips
{
    class 呼び出しごとに0と1を繰り返す
    {
        public 呼び出しごとに0と1を繰り返す()
        {
            Console.WriteLine("呼び出しごとに0と1を繰り返す\r\n");

            // ^(XOR)を使用することで呼び出しの度に0と1を切り替えることができる
            int n = 1;
            // bool でも可能(意味はないけど)
            bool flg1 = true;
            bool flg2 = true;

            for(int i = 0; i < 5; i++)
            {
                // XORで 交互に0, 1 を反転させる
                n ^= 1;
                flg1 ^= true;
                flg2 = !flg2; // 普通に考えてこれが一番シンプル

                Console.Write($"{n}, {flg1}, {flg2}, "); // 「0」「false」から始まる
            }
        }
    }
}
