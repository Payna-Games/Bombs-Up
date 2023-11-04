using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompSpeed : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        speed = MiniBompManager.miniBompManager.speed;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}