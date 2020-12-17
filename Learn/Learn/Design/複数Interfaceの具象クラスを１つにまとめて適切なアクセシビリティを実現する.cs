using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 複数Interfaceの具象クラスを１つにまとめて適切なアクセシビリティを実現する
/// 役割毎に具象クラスを別に定義しないのは、呼び出し側での利便性のため
/// この例では、呼び出し元であるコンストラクタは常にUser具象クラスのみをインスタンスとして生成すればいい
/// これはテスタビリティ的にもいい影響がある？
/// (具象クラスとのマッピングがIUserとUserに一本化するためDIコンテナがスッキリする？
/// ただ、そうするとIUserクラスが「全ユーザに共通する機能定義」と「DIコンテナとマッピングする」２つの役割を持つことにならないか？)
/// </summary>

// https://qiita.com/yutorisan/items/d28386f168f2f3ab166d

namespace Learn.Design
{
    /// <summary>
    /// 全ユーザに共通する機能
    /// </summary>
    public interface IUser
    {
        // どんなユーザでもCRはできる
        public int? Create(string data);
        public string Read(int id);
    }

    /// <summary>
    /// 管理者のみに許された機能
    /// </summary>
    public interface IAdminUser : IUser
    {
        // 管理者はすべてのデータのUDできる
        public bool Update(int id, string data);
        public bool Delete(int id);
    }

    /// <summary>
    /// 一般ユーザに公開された機能
    /// </summary>
    public interface ICommonUser : IUser
    {
        // 一般ユーザは自分のデータのUDできる
        public bool UpdateMyData(int id, string data);
        public bool DeleteMyData(int id);
    }

    /// <summary>
    /// 管理者、一般ユーザの具象クラスを１つにまとめる
    /// </summary>
    public class User : ICommonUser, IAdminUser
    {
        public User()
        {

        }

        public int? Create(string data)
        {
            // なんかデータを作る処理(ここでは常に成功)
            // 成功したらidが返ってくる
            // 失敗したらnullが返ってくる感じ
            return 2;
        }

        public string Read(int id)
        {
            // なんかデータを読む処理
            return "データの中身";
        }

        public bool Update(int id, string data) => true;

        public bool Delete(int id) => true;

        public bool UpdateMyData(int id, string data) => true;

        public bool DeleteMyData(int id) => true;
    }

    class 複数Interfaceの具象クラスを１つにまとめて適切なアクセシビリティを実現する
    {
        public 複数Interfaceの具象クラスを１つにまとめて適切なアクセシビリティを実現する()
        {
            Console.WriteLine("複数Interfaceの具象クラスを１つにまとめて適切なアクセシビリティを実現する\r\n");

            // どんなユーザでも具象クラスはUser
            User user = new User();
            // 実装されている全メソッドを使える
            user.Delete(1); // 本来は管理者しか使えない想定
            user.DeleteMyData(1); // 一般ユーザしか使えない想定(管理者は使用する必要がない機能)


            // 呼び出し側で適切なアクセシビリティで具象クラスを作成する
            ICommonUser commonUser = new User();
            commonUser.DeleteMyData(1); // 自分のデータは消せる
            //commonUser.Delete(1); // これは呼べない。適切にアクセシビリティがコントロールされている。

            IAdminUser adminUser = new User();
            adminUser.Delete(1);
            //adminUser.DeleteMyData(1); // これは呼べない。そもそも全データを削除できるので不要(要らないメソッドを隠匿できる)
        }

    }
}
