using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCount : MonoBehaviour
{
    public static ClickCount clickCount;
    public int goClickCount;

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
    }
}
