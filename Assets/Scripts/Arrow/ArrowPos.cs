using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPos : MonoBehaviour
{
    public Transform arrowPos;

    private void FixedUpdate()
    {
        transform.position = arrowPos.position;
    }
}
