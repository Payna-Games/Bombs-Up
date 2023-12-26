using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensActivate : MonoBehaviour
{
    private void Start()
    {
        ClickCount.clickCount.FireColor += LensActive;
    }

    public void LensActive()
    {
        StartCoroutine(LensActiveTime());
        
    }

    private IEnumerator LensActiveTime()
    {
        yield return new WaitForSeconds(1.5f);
        transform.GetChild(0).gameObject.SetActive(true);
        
    }
}
