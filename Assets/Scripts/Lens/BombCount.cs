using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCount : MonoBehaviour
{
    [SerializeField] private int bombCount;
   // private int addBombCount;

    public int AddBombCount()
    {
        
        return bombCount;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.TryGetComponent()) ;
    // }
}
