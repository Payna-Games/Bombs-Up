using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensWaitTime : MonoBehaviour
{

    public static LensWaitTime lensW;
    public bool lensActive = false;

    private void Awake()
    {
        
        lensW = lensW == null ? this : lensW;
    }

    public  IEnumerator LensActive()
    {
        yield return new WaitForSeconds(0.5f);
        lensActive = false;
            
    
        
    }
}

