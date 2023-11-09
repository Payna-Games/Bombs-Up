using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Interactive : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Hareket hızı
    private bool movingRight = true; // Başlangıçta sağa doğru hareket etsin

    void Update()
    {
        
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        
        if (transform.position.x >= 14f)
        {
            movingRight = false;
        }
        
        else if (transform.position.x <= -25f)
        {
            movingRight = true;
        }
    }
}
