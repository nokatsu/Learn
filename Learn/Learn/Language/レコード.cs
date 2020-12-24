using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Language
{
    // https://qiita.com/shimamura_io/items/80982b11ce41eca03e10
    // https://mslgt.hatenablog.com/entry/2020/12/04/224410

    public class レコード
    {
        // C# 9 から！

        // Classと似たようなもの(recordも参照型、IL的にはclassらしい)
        // Classとの違いは値ベースで比較(.Equals)可能であるということ
        // Class（参照型）で値ベースの比較を行わせるようにするには、
        // 自前でEqualsやGetHashCodeをoverrideする必要があるが、
        // recordはそれらを自動で実装してくれる=実装の手間が省ける

        public レコード()
        {
            Console.WriteLine("\r\nレコード\r\n");

            // Class
            var personClass1 = new PersonClass("Bill", "Wagner");
            var personClass2 = new PersonClass("Bill", "Wagner");

            // 参照型の比較(.Equals)は参照先のオブジェクトが同一である場合にtrueとなる
            // これはメンバの内容は一緒でも参照先が異なるためfalse
            Console.WriteLine(personClass1.Equals(personClass2));
            Console.WriteLine(personClass1.ToString());


            // Record
            var personRecord1 = new PersonRecord("Bill", "Wagner");
            var personRecord2 = new PersonRecord("Bill", "Wagner");

            // Recordも参照型だがこれはtrue
            // Recordの比較(.Equals)は値ベースの等価比較のためのメソッドとして自動実装される
            // GetHashCode() のオーバーライドも自動実装！
            Console.WriteLine(personRecord1.Equals(personRecord2));
            Console.WriteLine(personRecord1.ToString());


            // Struct
            var personStruct1 = new PersonStruct("Bill", "Wagner");
            var personStruct2 = new PersonStruct("Bill", "Wagner");

            // 構造体は値型なのでこれはtrue
            Console.WriteLine(personStruct1.Equals(personStruct2));
            Console.WriteLine(personStruct1.ToString());


            // じゃあ、構造体でいいかというと違う
            var KeishoRecord1= new KeishoRecord(new List<int> { 1, 2 });
            var KeishoRecord2 = new KeishoRecord(new List<int> { 1, 2 });

            // Recordは内部的にはClassなので、継承ができる
            // ここが強い
            KeishoRecord1.Something();

            // Recordの比較(.Equals)は値ベースの等価比較のためのメソッドとして自動実装されるが
            // プロパティが参照型(今回はList<int>)である場合は等価とならないので注意！
            // DeepCopyは作成せずに比較する模様
            // これは構造体も一緒
            Console.WriteLine(KeishoRecord1.Equals(KeishoRecord2));
            Console.WriteLine(KeishoRecord1.ToString());
        }


        /// <summary>
        /// 普通のクラス
        /// </summary>
        private class PersonClass
        {
            public string LastName { get; }
            public string FirstName { get; }

            public PersonClass(string first, string last) => (FirstName, LastName) = (first, last);
        }

        /// <summary>
        /// ！！レコード！！
        /// </summary>
        private record PersonRecord
        {
            public string LastName { get; init; }
            public string FirstName { get; init; }

            public PersonRecord(string first, string last) => (FirstName, LastName) = (first, last);
        }

        /// <summary>
        /// これは↑のRecordと同一
        /// デフォルトで init セッターが使用されるので注意！
        /// </summary>
        private record PersonRecordSame(string LastName, string FirstName);

        /// <summary>
        /// 構造体
        /// </summary>
        private struct PersonStruct
        {
            public string LastName { get; }
            public string FirstName { get; }

            public PersonStruct(string first, string last) => (FirstName, LastName) = (first, last);
        }

        private record KeishoRecord : ISomething
        {
            public List<int> Nums { get; init; }

            public KeishoRecord(List<int> nums) => Nums = nums;

            public void Something()
            {
                Console.WriteLine("interfaceの実装！");
            }
        }

        private interface ISomething
        {
            public void Something();
        }

    }
}
