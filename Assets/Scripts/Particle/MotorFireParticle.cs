using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotorFireParticle : MonoBehaviour
{

    public static MotorFireParticle motorFireParticle;

    private void Awake()
    {
        motorFireParticle = motorFireParticle == null ? this : motorFireParticle;
    }

    private void Start()
    {
        ClickCount.clickCount.FireColor += BombFire;

    }



    public void BombFire()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);


    }



}