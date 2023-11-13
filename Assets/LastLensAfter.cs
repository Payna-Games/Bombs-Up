using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLensAfter: MonoBehaviour
{
    public static LastLensAfter lastLensAfter;
    public bool lastLensPassed = false;

    private void Awake()
    {
        lastLensAfter = lastLensAfter== null ? this : lastLensAfter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bomb"))
        {
            lastLensPassed = true;
        }
    }
}
