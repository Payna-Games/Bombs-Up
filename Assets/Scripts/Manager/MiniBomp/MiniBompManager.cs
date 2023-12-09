using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompManager : MonoBehaviour
{
    public static MiniBompManager miniBompManager;
    

    public int speed;
    public float spawnSpeed;
    public int range;



    private void Awake()
    {
        miniBompManager = miniBompManager == null ? this : miniBompManager;
    }

    private void Start()
    {
        
            spawnSpeed = 0.4f;
            speed = 80;
            range = 120;
            //spawnSpeed = Mathf.Clamp(spawnSpeed, 0.2f, 1.5f);
      
    }
}
