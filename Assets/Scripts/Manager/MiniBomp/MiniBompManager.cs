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
        if (PlayerPrefs.HasKey("Range"))
            range = PlayerPrefs.GetInt("Range");
        else
            range = 120;
        if (PlayerPrefs.HasKey("Rate"))
            spawnSpeed = PlayerPrefs.GetFloat("Rate");
        else
            spawnSpeed = 0.70f;

        speed = 80;

    }
    public void RangePlus()
    {
        range += 1;
        PlayerPrefs.SetInt("Range", range);
    }
    public void RatePlus()
    {
        spawnSpeed -= 0.02f;
        PlayerPrefs.SetFloat("Rate", spawnSpeed);
    }
}
