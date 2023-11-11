using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombLeftRight: MonoBehaviour
{
    [SerializeField] private float swipeSpeed = 0.1f;
    [SerializeField] private float maxDistanceRight;
    [SerializeField] private float maxDistanceLeft;
    public float bombSpeed = 5f;
    
   // [SerializeField] private Vector3 forceDirection;
    //[SerializeField] private float forceMagnitude = 10.0f;
    
    private Touch touch;
    private Drop drop;
    [SerializeField] private float damping = 5f;
    
    private void Start()
    {
        drop = GetComponent<Drop>();
       

    }

    private void Update()
     {
         if (drop.rotateComplete)
         {
             Vector3 move = new Vector3(0, bombSpeed*Time.deltaTime, 0);
             transform.Translate(move);
             
             if (Input.touchCount > 0)
             {
                 touch = Input.GetTouch(0);
                 {
                     if (touch.phase == TouchPhase.Moved)
                     {
                         float targetX = transform.position.x + touch.deltaPosition.x * -swipeSpeed;
                         targetX = Mathf.Clamp(targetX, maxDistanceRight, maxDistanceLeft);

                         // Damping uygulayarak objeyi hedef konuma hareket ettirin
                         SmoothMove(targetX);
                     }
                 }
             }
         }
         
        
         
     }
     private void SmoothMove(float targetX)
{
    // Mevcut konumu alın
    Vector3 currentPosition = transform.position;

    // Damping uygulayarak hedef konuma doğru yumuşak bir şekilde hareket ettirin
    Vector3 smoothedPosition = Vector3.Lerp(currentPosition, new Vector3(targetX, currentPosition.y, currentPosition.z), Time.deltaTime * damping);

    // Yeni konumu ayarlayın
    transform.position = smoothedPosition;
}

    
}