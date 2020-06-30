using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    Vector3 defaultPosition = Vector3.zero;

    void Start()
    {
        defaultPosition = transform.position;
    }

    public void Execute()
    {
        transform.position = defaultPosition;
    }
}
