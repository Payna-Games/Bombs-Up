using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompRotationY : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public Drop drop;

    private bool isRotate = false;
    private void Start()
    {
        if (drop != null)
        {
            if (drop.rotateComplete)
            {
                isRotate = true;
            }
        }
        else
        {
            transform.parent.parent.GetComponent<Drop>().windPlay += RotateActive;
        }

    }

    void Update()
    {
        if (isRotate)
        {
            if (Input.GetMouseButton(0))
            {
                transform.Rotate(Vector3.up, 8f * rotationSpeed * Time.deltaTime);
            }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    transform.Rotate(Vector3.up, 8f * rotationSpeed * Time.deltaTime);
                }
            }
            else
                transform.Rotate(Vector3.up, 4 * rotationSpeed * Time.deltaTime);
        }
    }
    public void RotateActive()
    {
        isRotate = true;
    }
}
