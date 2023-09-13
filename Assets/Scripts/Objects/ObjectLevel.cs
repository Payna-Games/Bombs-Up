using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLevel : MonoBehaviour
{
    private int createdLevel;
    public int objectLevel;

    public event Action<int> OnLevelUp;

    public void LevelUp()
    {
        objectLevel++;
        OnLevelUp?.Invoke(objectLevel);
    }
    
    public void LevelUp(int level)
    {
        objectLevel = level;
        OnLevelUp?.Invoke(objectLevel);
    }
    public void LevelDown(int level)
    {
        objectLevel = level;
        OnLevelUp?.Invoke(objectLevel);
    }
    private void OnEnable()
    {
        createdLevel = 0;
        LevelUp(createdLevel);
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
            if (child != transform && !child.CompareTag("Text"))
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
