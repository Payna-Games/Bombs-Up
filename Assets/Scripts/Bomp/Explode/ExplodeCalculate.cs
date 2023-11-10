using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCalculate : MonoBehaviour
{
    public float RadiusExplode()
    {
        return (transform.GetChild(1).GetComponent<ObjectLevel>().objectLevel + 1) * 20;
        // 36 olan deger 20 olacak //
    }

    public float ForceExplode()
    {
        return 13f;
    }
}
