using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCalculate : MonoBehaviour
{
    public float RadiusExplode()
    {
        int kTon = KiloTonCalculate.kiloTonCalculate.KiloTon;
        if (kTon == 100)
            return kTon / 5;
        if (kTon > 100 && kTon <= 160)
            return kTon / 4;
        if (kTon > 160 && kTon <= 250)
            return kTon / 4.16f;
        if (kTon > 250 && kTon <= 370)
            return kTon / 4.625f;
        if (kTon > 370 && kTon <= 520)
            return kTon / 5.2f;
        if (kTon > 520 && kTon <= 700)
            return kTon / 5.83f;
        if (kTon > 700 && kTon <= 910)
            return kTon / 6.5f;
        if (kTon > 910)
            return kTon / 7.18f;
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
