using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCalculate : MonoBehaviour
{
    public float RadiusExplode()
    {
        return (transform.GetChild(1).GetComponent<ObjectLevel>().objectLevel + 1) * 17;
    }

    public float ForceExplode()
    {
        return (transform.GetChild(0).GetComponent<ObjectLevel>().objectLevel +1 ) * 13f;
    }
}
