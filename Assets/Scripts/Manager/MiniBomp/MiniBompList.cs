using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompList : MonoBehaviour
{
    public static MiniBompList miniBompList;

    public List<GameObject> miniBomp;

    private void Awake()
    {
        miniBompList = miniBompList == null ? this : miniBompList;
    }
}
