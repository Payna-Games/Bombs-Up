using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLevel : MonoBehaviour
{
    private int createdLevel;
    public int objectLevel;
    public int damageLevel;

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

    private void Start()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            createdLevel = PlayerPrefs.GetInt(transform.name);
        }
        else
        {
            createdLevel = 0;
        }
        ObjectActive(createdLevel);
    }
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            createdLevel = PlayerPrefs.GetInt(transform.name);
        }
        else
        {
            createdLevel = 0;
        }
        ObjectActive(createdLevel);
    }

    public void ObjectActive(int level)
    {
        LevelUp(level);
        SetFalse();
        SetTrue();
        OnLevelUp?.Invoke(objectLevel);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(transform.name, objectLevel);
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
    public void SetTrue2()
    {
        transform.GetChild(damageLevel).gameObject.SetActive(true);
    }

    public void SetFalse2()
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
