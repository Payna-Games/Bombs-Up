using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompManager : MonoBehaviour
{
    public static MiniBompManager miniBompManager;

    public int speed;
    public int spawnSpeed;
    public int range;

    private void Awake()
    {
        miniBompManager = miniBompManager == null ? this : miniBompManager;
    }
}
