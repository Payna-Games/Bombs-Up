using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketParticleControl : MonoBehaviour
{
    private BompExplode bompExplode;

    public GameObject particleExplode;

    private Drop drop;
    private bool isScreenDown;
    private bool particleBool = false;
    private float heldDownSimulationSpeed = 2.0f;
    private float releasedSimulationSpeed = 1.0f;

    private void Awake()
    {
        bompExplode = transform.parent.GetComponent<BompExplode>();
        drop = transform.parent.GetComponent<Drop>();
        drop.windPlay += Drop_windPlay;
        bompExplode.explode += ExplodeParticle;
    }

    private void Drop_windPlay()
    {
        particleBool = true;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
    }

    private void ExplodeParticle(GameObject particle)
    {
        GameObject particleExp =  Instantiate(particleExplode, particle.transform.position, Quaternion.identity);
        particleExp.GetComponent<ParticleSystem>().Play();
    }

    public void RocketStartSmoke()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
        StartCoroutine(StartSmokeCoroutine());
    }
    private IEnumerator StartSmokeCoroutine()
    {
        yield return new WaitForSeconds(3f);
        transform.GetChild(2).gameObject.SetActive(false);
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