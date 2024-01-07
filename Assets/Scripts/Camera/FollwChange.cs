using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using YsoCorp.GameUtils;

public class FollwChange : MonoBehaviour
{
    public Transform bomps;
    public Transform cityGround;


    Animator animator;
    [HideInInspector] public bool isFirst = true;
    // public int min = 120;
    // public int max = 170;

    public event Action changeCamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        // float rangeY = bomps.position.y - cityGround.position.y;
        // if (rangeY <= max && rangeY >= min & isFirst)
        if(LastLensAfter.lastLensAfter.lastLensPassed)
        {
           
            CameraChange();
            changeCamera?.Invoke();
            cityGround.gameObject.isStatic = false;

            isFirst = false;
        }
    }

    public void CameraChange()
    {
        animator.Play("CityCamera");
    }
    public void SwitchCamera(int newCameraIndex)
    {
        StartCoroutine(CameraChangeWaitTime());
        
      
        
        
    }

    private IEnumerator CameraChangeWaitTime()
    {
        if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            yield return new WaitForSeconds(1f);
        }
        else if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            yield return new WaitForSeconds(3f);
        }
        else
        {
            yield return new WaitForSeconds(3f);
        }


        
        // SwitchCamera(1);
        animator.Play("FreeLook");

    }
}
