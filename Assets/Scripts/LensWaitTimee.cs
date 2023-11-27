using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensWaitTime : MonoBehaviour
{

    public static LensWaitTime LensW;
    public bool lensActive;

    private void Awake()
    {
        
        LensW = LensW == null ? this : LensW;
        lensActive = false;
    }

    public  IEnumerator LensActive()
    {
        yield return new WaitForSeconds(1.5f);
        lensActive = false;
            
    
        
    }
}

