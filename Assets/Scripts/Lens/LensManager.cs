using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LensManager lensManager;
    public bool particleControl;
    private void Awake()
    {
        lensManager = lensManager == null ? this : lensManager;
    }

    
    void Update()
    {
        
    }
}
