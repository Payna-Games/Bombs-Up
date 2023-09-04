using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLevel : MonoBehaviour
{
    public int objectLevel;

    public void LevelUp()
    {
        objectLevel++;
    }

    public void SetTrue()
    {
        transform.GetChild(objectLevel).gameObject.SetActive(true);
    }

    public void SetFalse()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            if (child != transform) // Kendisi hariç
            {
                // SetActive özelliðini ayarla
                child.gameObject.SetActive(false);
            }
        }

        //foreach (Transform child in transform)
        //{
        //    if (child != transform) // Kendisi hariç
        //    {
        //        child.gameObject.SetActive(false);
        //    }

        //}
    }
}
