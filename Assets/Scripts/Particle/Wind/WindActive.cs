using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindActive : MonoBehaviour
{
    public FollwChange follwChange;
    void Start()
    {
        follwChange.changeCamera += WindParticleActive;
    }

    private void WindParticleActive()
    {
        gameObject.SetActive(false);
    }
}
