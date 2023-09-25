using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketParticleControl : MonoBehaviour
{
    private Drop drop;
    public GameObject windPlarticle;
    private bool isScreenDown;
    private bool particleBool = false;
    private float heldDownSimulationSpeed = 2.0f;
    private float releasedSimulationSpeed = 1.0f;

    private void Awake()
    {
        drop = transform.parent.GetComponent<Drop>();
        drop.windPlay += Drop_windPlay;
    }

    private void Drop_windPlay()
    {
        particleBool = true;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
    }
    private void Update()
    {
        if (particleBool)
        {
            if (Input.GetMouseButton(0))
            {
                isScreenDown = true;
            }
            else
            {
                isScreenDown = false;
            }
            var mainModule = transform.GetChild(1).GetComponent<ParticleSystem>().main;
            mainModule.simulationSpeed = isScreenDown ? heldDownSimulationSpeed : releasedSimulationSpeed;
        }
    }
}