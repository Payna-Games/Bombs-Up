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

    public event Action changeCamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float rangeY = bomps.position.y - cityGround.position.y;
        if (rangeY <= 170 && rangeY >= 120 & isFirst)
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
}
