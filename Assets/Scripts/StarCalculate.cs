using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCalculate : MonoBehaviour
{
    [SerializeField] private BompExplode bombExplode;
    [SerializeField] private Kill kill;
    public float starRate;
    private void Awake()
    {
        bombExplode.explodeCount += StarCalculatee;
        
        
    }

    private void StarCalculatee( int objCount)
    {
         starRate = (float)objCount / kill.maxObj;
         Debug.Log("çalıştı" + starRate );
    }
}
