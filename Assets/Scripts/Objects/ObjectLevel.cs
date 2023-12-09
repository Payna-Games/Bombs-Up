using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLevel : MonoBehaviour
{
    private int createdLevel;
    public int objectLevel;
    public int damageLevel;
    public Transform bombComponent;

    public event Action<int> OnLevelUp;
    public event Action<int> otherBomp;
    

    public void LevelUp()
    {
        objectLevel++;
        if (transform.parent.CompareTag("Bomb"))
            PlayerPrefs.SetInt(transform.name, objectLevel);
        OnLevelUp?.Invoke(objectLevel);
    }

    public void LevelUp(int level)
    {
        objectLevel = level;
        if (transform.parent.CompareTag("Bomb"))
            PlayerPrefs.SetInt(transform.name, objectLevel);
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
        damageLevel = objectLevel;
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
        bombComponent = transform.GetChild(damageLevel);
        bombComponent.gameObject.SetActive(true);
        Debug.Log("damage level" + damageLevel);

        
         
        
        
        

        otherBomp?.Invoke(damageLevel);
        

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
