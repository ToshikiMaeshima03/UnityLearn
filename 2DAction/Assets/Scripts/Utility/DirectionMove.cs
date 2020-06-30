using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMove : MonoBehaviour
{
    [SerializeField] Vector3 velocity = Vector3.zero;


    void Update()
    {
        transform.Translate(velocity);
    }
}
