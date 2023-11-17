using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneParticleScript : MonoBehaviour
{
    
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

   
}
