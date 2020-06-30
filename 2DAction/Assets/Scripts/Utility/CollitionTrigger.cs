using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollitionTrigger : MonoBehaviour
{
    //UnityEvent自体にコールバックの機能がついているがジェネリックがあるので
    //抽象的なクラスとして扱う為Unity上で表示できない
    //なのでUnity上で設定する場合は継承してジェネリック部分を埋める必要がある
    [Serializable] public class CallBackFunction : UnityEvent<GameObject> { }

    //当たり判定始めに呼ばれる関数
    [SerializeField] CallBackFunction enterFunction;
    //当たり判定終わりに呼ばれる関数
    [SerializeField] CallBackFunction exitFunction;

    //タグを複数持てるようにリスト管理
    [SerializeField] List<string> tags = new List<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Listの中から、collision.tagと一致するものがあるかどうか検索.
        if (tags.Contains(collision.tag))
        {
            enterFunction.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Listの中から、collision.tagと一致するものがあるかどうか検索.
        if (tags.Contains(collision.tag))
        {
            exitFunction.Invoke(collision.gameObject);
        }
    }
}
