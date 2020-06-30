using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float baseScale = 1.5f;

    Rigidbody2D rigidbody2D = null;
    bool isOnCollistion = false;
    bool isRightDirection = true;

    void Start()
    {
        if (TryGetComponent(out rigidbody2D) == false)
        {
            Debug.LogError("RigidBody2Dが見つかりません");
        }
    }

    void Update()
    {
        if (isOnCollistion)
        {
            isRightDirection = !isRightDirection;
        }

        float x = -1.0f;
        if (isRightDirection)
        {
            x = 1.0f;
        }
        transform.localScale = new Vector3(x*baseScale,baseScale);

        var velocity = rigidbody2D.velocity;
        velocity.x = x * speed;
        rigidbody2D.velocity = velocity;
    }
    public void EnterCollisiton(GameObject gameObject)
    {
        isOnCollistion = true;
    }

    public void ExitCollisiton(GameObject gameObject)
    {
        isOnCollistion = false;
    }
}
