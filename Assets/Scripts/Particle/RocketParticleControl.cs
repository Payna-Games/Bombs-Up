using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketParticleControl : MonoBehaviour
{
    private Drop drop;
    public ParticleSystem windPlarticle;

    private void Awake()
    {        
        drop = transform.parent.GetComponent<Drop>();
        drop.windPlay += Drop_windPlay;
    }

    private void Drop_windPlay()
    {
        ParticleSystem particleWind = Instantiate(windPlarticle, transform.parent.position, new Quaternion(transform.parent.rotation.x, transform.parent.rotation.y, transform.parent.rotation.z + 90f, 1));
        particleWind.Play();
    }
}
