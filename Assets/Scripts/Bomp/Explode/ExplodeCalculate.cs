using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCalculate : MonoBehaviour
{
    public float RadiusExplode()
    {
        int kTon = KiloTonCalculate.kiloTonCalculate.KiloTon;
        if (kTon == 100)
            return 30f;
        if (kTon > 100 && kTon <= 160)
            return kTon / 3.75f;
        if (kTon > 160 && kTon <= 250)
            return kTon / 3.50f;
        if (kTon > 250 && kTon <= 370)
            return kTon / 3.25f;
        if (kTon > 370 && kTon <= 520)
            return kTon / 3.10f;
        if (kTon > 520 && kTon <= 700)
            return kTon / 3f;
        if (kTon > 700 && kTon <= 910)
            return kTon / 2.80f;
        if (kTon > 910)
            return kTon / 2.70f;
        else
            return 0;
        
        //return (transform.GetChild(1).GetComponent<ObjectLevel>().objectLevel + 1) * 20;
        // 36 olan deger 20 olacak //
    }

    public float ForceExplode()
    {
        return 13f;
    }
}
