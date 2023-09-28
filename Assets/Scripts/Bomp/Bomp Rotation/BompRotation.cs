using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompRotation : MonoBehaviour
{
    private Vector2 ilkDokunmaPozisyonu;
    private FollwChange follwChange;
    private float döndürmeHassasiyeti = 0.6f;
    float rotationAngle = 0;

    public bool loop = false;

    public float maxValueX;
    private void Awake()
    {
        follwChange = GameObject.Find("State-Driven Camera").GetComponent<FollwChange>();
        follwChange.changeCamera += BoolFalse;
    }

    void FixedUpdate()
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
    public void BoolFalse()
    {
        loop = false;
    }

    private void RotateAndDown()
    {

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {
                ilkDokunmaPozisyonu = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
            {
                Vector2 dokunmaDeðiþim = Input.GetTouch(0).position - ilkDokunmaPozisyonu;

                rotationAngle = dokunmaDeðiþim.x * döndürmeHassasiyeti * Time.deltaTime;
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

        if (rotationAngle > 0 && Mathf.Abs(transform.position.x) < maxValueX )
        {
            transform.position += Vector3.right * ((rotationAngle / 10) + 2);
        }
        else if (rotationAngle < 0 && Mathf.Abs(transform.position.x) < maxValueX)
        {
            transform.position += Vector3.left * ((rotationAngle / 10) + 2);
        }
    }
}
