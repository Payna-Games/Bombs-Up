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
    public void LevelUp(int level)
    {
        objectLevel = level;
    }
    public void LevelDown(int level)
    {
        objectLevel = level;
    }
    private void OnEnable()
    {
        objectLevel = 0;
        SetFalse();
        SetTrue();
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
            if (child != transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
