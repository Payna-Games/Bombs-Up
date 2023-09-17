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
    bool isFirst = true;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float rangeY = bomps.position.y - cityGround.position.y;
        if (rangeY <= 160 && rangeY >= 130 & isFirst)
        {
            isFirst = false;
            CameraChange();
        }
    }

    public void CameraChange()
    {
        animator.Play("CityCamera");
    }
}
