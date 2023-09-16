using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompRotation : MonoBehaviour
{
    private Vector2 ilkDokunmaPozisyonu;
    private float d�nd�rmeHassasiyeti = 0.5f;
    public bool loop = false;

    void Update()
    {
        if (loop)
        {
            RotateAndDown();
        }
    }
    public void BoolTrue()
    {
        loop = true;
    }

    private void RotateAndDown()
    {
        float d�nd�rmeA��s� = 0;
        if (Input.touchCount > 0)
        {
            // �lk dokunma pozisyonunu kaydedin.
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
            // Dokunma devam ediyorsa nesneyi d�nd�r�n.
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Dokunma noktas�ndaki pozisyon de�i�imini hesaplay�n.
                Vector2 dokunmaDe�i�im = Input.GetTouch(0).position - ilkDokunmaPozisyonu;

                // Nesneyi sa�a veya sola d�nd�r�n.
                d�nd�rmeA��s� = dokunmaDe�i�im.x * d�nd�rmeHassasiyeti * Time.deltaTime;
                transform.Rotate(Vector3.forward, d�nd�rmeA��s�);


                // �lk dokunma pozisyonunu g�ncelleyin.
                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
        }
        transform.position += Vector3.down;
        if (d�nd�rmeA��s� > 0)
        {
            transform.position += Vector3.right*2;
        }
        else if (d�nd�rmeA��s� < 0)
        {
            transform.position += Vector3.left*2;
        }
    }
}
