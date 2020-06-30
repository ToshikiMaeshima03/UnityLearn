using UnityEngine;

//シングルトン可する継承先クラスの宣言は以下のようにする
// public class MyManager : Singleton<MyManager>{}

//アクセス方法.
//MyManager.instance.Func();

public class Singleton<T> : MonoBehaviour
     where T : MonoBehaviour
{
    private static T _instance = null;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                //インスペクターにあるかチェック、ある場合は取得して終了
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    //インスペクターになければ作成する
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    Debug.LogWarning("指定したシングルトンのオブジェクトが見つからなかったので作成 = " + typeof(T));
                }
            }
            return _instance;
        }
    }
}
