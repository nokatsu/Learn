using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Net
{
    // https://qiita.com/YuMo_tea/items/02673b1683e643c8d30a
    
    public class シャローコピーとディープコピー
    {
        public シャローコピーとディープコピー()
        {
            Console.WriteLine("\r\nシャローコピーとディープコピー\r\n");

            var sample = new SampleClass(1, "a", new List<int> { 1, 2 }, new List<string> { "a", "b" },
                new SubClass(1, new List<int> { 1, 2 }), new List<SubClass> { new SubClass(1, new List<int> { 1, 2 }) });
            var copy = sample.SharrowCopy();

            copy.Num = 100; // intは値型なので影響なし
            copy.Nums[0] = 100; // List<int>は参照型なので影響あり
            copy.Str = "z"; // stringは参照型だが、必ずコピーされるため影響なし
            copy.Strs[0] = "z"; // List<string>は参照型なので影響あり
            copy.Sub.Num = 100; // SubClassは参照型なので影響あり
            copy.Sub.Nums[0] = 100; // SubClassは参照型なので影響あり
            copy.Subs[0].Num = 100; // List<SubClass>は参照型なので影響あり
            copy.Subs[0].Nums[0] = 100; // List<SubClass>は参照型なので影響あり

            Console.WriteLine("\r\nシャローコピー\r\n");
            Console.WriteLine($"Num: {sample.Num}, {copy.Num}");
            Console.WriteLine($"Nums[0]: {sample.Nums[0]},  {copy.Nums[0]}");
            Console.WriteLine($"Str: {sample.Str}, {copy.Str}");
            Console.WriteLine($"Strs[0]: {sample.Strs[0]}, {copy.Strs[0]}");
            Console.WriteLine($"Sub.Num: {sample.Sub.Num}, {copy.Sub.Num}");
            Console.WriteLine($"Sub.Nums[0]: {sample.Sub.Nums[0]}, {copy.Sub.Nums[0]}");
            Console.WriteLine($"Subs[0].Num: {sample.Subs[0].Num}, {copy.Subs[0].Num}");
            Console.WriteLine($"Subs[0].Nums[0]: {sample.Subs[0].Nums[0]}, {copy.Subs[0].Nums[0]}");

            sample = new SampleClass(1, "a", new List<int> { 1, 2 }, new List<string> { "a", "b" },
                new SubClass(1, new List<int> { 1, 2 }), new List<SubClass> { new SubClass(1, new List<int> { 1, 2 }) });
            copy = sample.DeepCopyKuso();

            copy.Num = 100;
            copy.Nums[0] = 100;
            copy.Str = "z";
            copy.Strs[0] = "z";
            copy.Sub.Num = 100;
            copy.Sub.Nums[0] = 100;
            copy.Subs[0].Num = 100;
            copy.Subs[0].Nums[0] = 100;

            Console.WriteLine("\r\nダメなディープコピー\r\n");
            Console.WriteLine($"Num: {sample.Num}, {copy.Num}");
            Console.WriteLine($"Nums[0]: {sample.Nums[0]},  {copy.Nums[0]}");
            Console.WriteLine($"Str: {sample.Str}, {copy.Str}");
            Console.WriteLine($"Strs[0]: {sample.Strs[0]}, {copy.Strs[0]}");
            Console.WriteLine($"Sub.Num: {sample.Sub.Num}, {copy.Sub.Num}");
            Console.WriteLine($"Sub.Nums[0]: {sample.Sub.Nums[0]}, {copy.Sub.Nums[0]}");
            Console.WriteLine($"Subs[0].Num: {sample.Subs[0].Num}, {copy.Subs[0].Num}");
            Console.WriteLine($"Subs[0].Nums[0]: {sample.Subs[0].Nums[0]}, {copy.Subs[0].Nums[0]}");

            sample = new SampleClass(1, "a", new List<int> { 1, 2 }, new List<string> { "a", "b" },
                new SubClass(1, new List<int> { 1, 2 }), new List<SubClass> { new SubClass(1, new List<int> { 1, 2 }) });
            copy = sample.DeepCopy();

            copy.Num = 100;
            copy.Nums[0] = 100;
            copy.Str = "z";
            copy.Strs[0] = "z";
            copy.Sub.Num = 100;
            copy.Sub.Nums[0] = 100;
            copy.Subs[0].Num = 100;
            copy.Subs[0].Nums[0] = 100;

            Console.WriteLine("\r\nディープコピー\r\n");
            Console.WriteLine($"Num: {sample.Num}, {copy.Num}");
            Console.WriteLine($"Nums[0]: {sample.Nums[0]},  {copy.Nums[0]}");
            Console.WriteLine($"Str: {sample.Str}, {copy.Str}");
            Console.WriteLine($"Strs[0]: {sample.Strs[0]}, {copy.Strs[0]}");
            Console.WriteLine($"Sub.Num: {sample.Sub.Num}, {copy.Sub.Num}");
            Console.WriteLine($"Sub.Nums[0]: {sample.Sub.Nums[0]}, {copy.Sub.Nums[0]}");
            Console.WriteLine($"Subs[0].Num: {sample.Subs[0].Num}, {copy.Subs[0].Num}");
            Console.WriteLine($"Subs[0].Nums[0]: {sample.Subs[0].Nums[0]}, {copy.Subs[0].Nums[0]}");
        }


        private class SampleClass
        {
            /// <summary>
            ///  値型プロパティ
            /// </summary>
            public int Num { get; set; }
            /// <summary>
            ///  値型プロパティ
            /// </summary>
            public string Str { get; set; }
            /// <summary>
            ///  参照型プロパティ
            /// </summary>
            public List<int> Nums { get; set; }
            /// <summary>
            ///  参照型プロパティ
            /// </summary>
            public List<string> Strs { get; set; }

            public SubClass Sub { get; set; }
            public List<SubClass> Subs { get; set; }

            public SampleClass(int num, string str, List<int> nums, List<string> strs, SubClass sub, List<SubClass> subs) => (Num, Str, Nums, Strs, Sub, Subs) = (num, str, nums, strs, sub, subs);

            public SampleClass SharrowCopy()
            {
                // シャローコピーの作成はMemberwiseClone()で行える
                return (SampleClass)MemberwiseClone();
            }

            public SampleClass DeepCopy()
            {
                SampleClass copy = SharrowCopy();

                if(copy.Nums is List<int> nums)
                {
                    copy.Nums = new List<int>(this.Nums);
                }

                if(copy.Strs is List<string> strs)
                {
                    copy.Strs = new List<string>(this.Strs);
                }

                if(copy.Sub is SubClass sub)
                {
                    copy.Sub = this.Sub.DeepCopy();
                }

                if(copy.Subs is List<SubClass> subs)
                {
                    copy.Subs = new List<SubClass>();
                    foreach(var item in subs)
                    {
                        copy.Subs.Add(item.DeepCopy());
                    }
                }

                return copy;
            }

            public SampleClass DeepCopyKuso()
            {
                SampleClass copy = SharrowCopy();

                if (copy.Nums is List<int> nums)
                {
                    copy.Nums = new List<int>(this.Nums);
                }

                if (copy.Strs is List<string> strs)
                {
                    copy.Strs = new List<string>(this.Strs);
                }

                if (copy.Sub is SubClass sub)
                {
                    copy.Sub = this.Sub.DeepCopy();
                }

                // ここがダメ！subsの中身のSubClassは参照を共有したまま
                if (copy.Subs is List<SubClass>subs)
                {
                    copy.Subs = new List<SubClass>(this.Subs);
                }

                return copy;
            }
        }

        public class SubClass //: ICloneable ←Clone()の実装を強制するだけ。DeepCopyであるかは保証しない。
        {
            public int Num { get; set; }
            public List<int> Nums { get; set; }

            public SubClass(int num, List<int> nums) => (Num, Nums) = (num, nums);

            public SubClass DeepCopy()
            {
                SubClass copy = (SubClass)MemberwiseClone();

                if(copy.Nums is List<int> nums)
                {
                    copy.Nums = new List<int>(this.Nums);
                }

                return copy;
            }
        }

    }
}
