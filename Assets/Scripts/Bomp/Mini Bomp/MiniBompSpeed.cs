using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompSpeed : MonoBehaviour
{
    public float speed = 5;

    private void Start()
    {
        speed = MiniBompManager.miniBompManager.speed;
    }

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}