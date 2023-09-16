using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompRotation : MonoBehaviour
{
    private Vector2 ilkDokunmaPozisyonu;
    private float döndürmeHassasiyeti = 0.5f;
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
        float döndürmeAçısı = 0;
        if (Input.touchCount > 0)
        {
            // İlk dokunma pozisyonunu kaydedin.
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
            // Dokunma devam ediyorsa nesneyi döndürün.
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Dokunma noktasındaki pozisyon değişimini hesaplayın.
                Vector2 dokunmaDeğişim = Input.GetTouch(0).position - ilkDokunmaPozisyonu;

                // Nesneyi sağa veya sola döndürün.
                döndürmeAçısı = dokunmaDeğişim.x * döndürmeHassasiyeti * Time.deltaTime;
                transform.Rotate(Vector3.forward, döndürmeAçısı);


                // İlk dokunma pozisyonunu güncelleyin.
                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
        }
        transform.position += Vector3.down;
        if (döndürmeAçısı > 0)
        {
            transform.position += Vector3.right*2;
        }
        else if (döndürmeAçısı < 0)
        {
            transform.position += Vector3.left*2;
        }
    }
}
