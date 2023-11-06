using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class FollwChange : MonoBehaviour
{
    public Transform bomps;
    public Transform cityGround;


    Animator animator;
    [HideInInspector] public bool isFirst = true;
    public int min = 120;
    public int max = 170;

    public event Action changeCamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        float rangeY = bomps.position.y - cityGround.position.y;
        if (rangeY <= max && rangeY >= min & isFirst)
        {
            cityGround.gameObject.isStatic = false;

            isFirst = false;
            CameraChange();
            changeCamera?.Invoke();
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
        yield return new WaitForSeconds(3);
        // SwitchCamera(1);
        animator.Play("BottomCamera");

    }
}
