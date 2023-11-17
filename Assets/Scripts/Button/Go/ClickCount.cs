using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickCount : MonoBehaviour
{
    public static ClickCount clickCount;
    public int goClickCount;
    public static event Action FireColor;
   

    private void Awake()
    {
        clickCount = clickCount == null ? this : clickCount;
        if (PlayerPrefs.HasKey(transform.name))
        {
            goClickCount = PlayerPrefs.GetInt(transform.name);
        }
    }
    
    public void GoClick()
    {
        goClickCount += 1;
        PlayerPrefs.SetInt(transform.name, goClickCount);
       
        FireColor?.Invoke();
    }

  
}
