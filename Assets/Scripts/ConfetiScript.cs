using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfetiScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem Confett;
    
    public void StartEffect()
    {
        ParticleSystem confett =Instantiate(Confett);
        confett.GetComponent<ParticleSystem>().Play();
    }
}


