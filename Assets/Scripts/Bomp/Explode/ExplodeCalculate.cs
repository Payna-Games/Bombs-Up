using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCalculate : MonoBehaviour
{
    public float RadiusExplode()
    {
        int kTon = KiloTonCalculate.kiloTonCalculate.KiloTon;
        if (kTon == 100)                    //1.level
            return 30f;
        if (kTon > 100 && kTon <= 160)      //2.level
            return kTon / 3.75f;
        if (kTon > 160 && kTon <= 250)      //3.level
            return kTon / 3.50f;
        if (kTon > 250 && kTon <= 370)      //4.level
            return kTon / 3.85f;
        if (kTon > 370 && kTon <= 520)      //5.level
            return kTon / 4.33f;
        if (kTon > 520 && kTon <= 700)      //6.level
            return kTon / 4.86f;
        if (kTon > 700 && kTon <= 910)      //7.level
            return kTon / 5.4f;
        if (kTon > 910)
            return kTon / 5.75f;            //8.level
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
