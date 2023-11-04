using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLeftRight: MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float maxDistanceRight;
    [SerializeField] private float maxDistanceLeft;
    [SerializeField] private float bombSpeed = 5f;
    private Drop drop;

    private void Start()
    {
        drop = GetComponent<Drop>();
    }

    private Touch touch;

     // private void Start()
     // {
     //     drop = GetComponent<Drop>();
     // }

     private void Update()
     {
         if (drop.rotateComplete)
         {
             Vector3 move = new Vector3(0, bombSpeed, 0);
             transform.Translate(move);
             if (Input.touchCount > 0)
             {
                 touch = Input.GetTouch(0);
                 {
                     if (touch.phase == TouchPhase.Moved)
                     {
                         transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * -speed,
                             transform.position.y, transform.position.z);

                         if (transform.position.x <= maxDistanceRight)
                         {
                             transform.position = new Vector3(maxDistanceRight, transform.position.y, transform.position.z);
                         }
                         else if (transform.position.x >= maxDistanceLeft)
                         {
                             transform.position = new Vector3(maxDistanceLeft, transform.position.y, transform.position.z);
                         }
                     }
                 }// private void Update()
                 // {
                 //     if (rotateComplete)
                 //     {
                 //         Vector3 move = new Vector3(transform.position.x, -bombSpeed * Time.deltaTime,
                 //             transform.position.z);
                 //        transform.Translate(move);
                 //     }
                 //     
                 // }
             }
         }
         
         
     }
}

