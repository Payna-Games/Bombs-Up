using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCalculate : MonoBehaviour
{
    public float RadiusExplode()
    {
        return (transform.GetChild(1).GetComponent<ObjectLevel>().objectLevel + 1) * 38;
    }

    public float ForceExplode()
    {
        return 13f;
    }
}
