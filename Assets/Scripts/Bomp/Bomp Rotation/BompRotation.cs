using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompRotation : MonoBehaviour
{
    private Vector2 ilkDokunmaPozisyonu;
    private float d�nd�rmeHassasiyeti = 0.05f;
    float rotationAngle = 0;

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

        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 dokunmaDe�i�im = Input.GetTouch(0).position - ilkDokunmaPozisyonu;

                rotationAngle = dokunmaDe�i�im.x * d�nd�rmeHassasiyeti * Time.deltaTime;
                float angleZ = transform.rotation.eulerAngles.z;
                Debug.Log("Rotate : " + rotationAngle);
                Debug.Log("Angle Z : " + angleZ);
                if ((angleZ > 200 && rotationAngle < 0) || (angleZ < 160 && rotationAngle > 0) || (angleZ < 195 && angleZ > 165))
                {
                    transform.Rotate(Vector3.forward, rotationAngle);

                }


                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
        }

        //transform.position += Vector3.down;
        if (rotationAngle > 0)
        {
            transform.position += Vector3.right;
        }
        else if (rotationAngle < 0)
        {
            transform.position += Vector3.left;
        }
    }
}
