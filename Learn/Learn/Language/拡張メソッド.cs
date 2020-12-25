using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // https://ufcpp.net/study/csharp/sp3_extension.html

    public class 拡張メソッド
    {
        public 拡張メソッド()
        {
            Console.WriteLine("\r\n拡張メソッド\r\n");

            string s = "This Is a Test String.";
            string s1 = StringExtensions.ToggleCase(s); // 通常の呼び出し方
            string s2 = s.ToggleCase();                 // 拡張メソッド呼び出し

            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }

    static class StringExtensions
    {
        /// <summary>
        /// 文字列の大文字と小文字を入れ替える。
        /// </summary>
        public static string ToggleCase(this string s)
        {
            // これが拡張メソッド
            // あたかもstringクラスのメソッドであるかのように使える
            // ↑「staticクラス」中に、 第一引数に this キーワードを修飾子として付けた static メソッドを書く
            
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsUpper(c))
                    sb.Append(char.ToLower(c));
                else if (char.IsLower(c))
                    sb.Append(char.ToUpper(c));
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
