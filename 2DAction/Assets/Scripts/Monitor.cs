using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    DirectionMove directionMove = null;

    void Start()
    {
        //子オブジェクトからCoinと名前がついているGameObjectを検索
        //検索出来た後にDirectionMoveコンポーネントを取得する
        if (transform.Find("Coin").TryGetComponent(out directionMove) == false)
        {
            Debug.LogError("DirectionMoveコンポーネントが見つかりません");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            directionMove.enabled = true;
        }
    }
}
