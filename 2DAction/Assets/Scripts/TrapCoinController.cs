using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapCoinController : MonoBehaviour
{
    DirectionMove directionMove = null;
    PositionReset positionReset = null;

    //コンポーネントを取得した時はTrueを返してくれる関数
    //変数前のoutは必ず結果が入ることを明示している
    void Start()
    {
        if (TryGetComponent(out directionMove))
        {
            directionMove.enabled = false;
        }
        else 
        {
            Debug.LogError("DirectionMoveが見つかりません");
        }

        if (TryGetComponent(out positionReset) == false)
        {
            Debug.LogError("PosisitonResetが見つかりません");
        }

        //実行時に自分自身をGameManagerに追加
        GameManager.instance.trapCoinControllers.Add(this);
    }

    public void ReStart()
    {
        directionMove.enabled = false;
        positionReset.Execute();
    }

}
