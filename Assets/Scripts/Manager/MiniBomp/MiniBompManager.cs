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
        if (LoopManagement.Loop.loop == 0)
        {
            spawnSpeed = 0.75f;
            speed = 80;
            range = 120;
            //spawnSpeed = Mathf.Clamp(spawnSpeed, 0.2f, 1.5f);
        }
        

       else  if (LoopManagement.Loop.loop  == 1)
        {
            spawnSpeed = 0.55f;
            speed = 80;
            range = 150;
        }
        else if (LoopManagement.Loop.loop  == 2)
        {
            spawnSpeed = 0.40f;
            speed = 80;
            range = 180;
        }
        else

        {
            spawnSpeed = 0.30f;
            speed = 80;
            range = 200; 
        }
    }
}
