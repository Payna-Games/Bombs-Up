using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketParticleControl : MonoBehaviour
{
    private BompExplode bompExplode;

    public GameObject particleExplode;
    public GameObject particleFireWork;

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
        drop.windPlay += Drop_Effect1;
        if (bompExplode != null)
        {
            bompExplode.explode += ExplodeParticle;
        }

    }

    private void Drop_Effect1()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
    }

    public void BompFire()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
    }

    private void Drop_windPlay()
    {
        particleBool = true;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
    }


    private void ExplodeParticle(GameObject particle)
    {
        int radius = transform.parent.GetChild(1).GetComponent<ObjectLevel>().objectLevel;

        GameObject particleExp = Instantiate(particleExplode, transform.position, Quaternion.identity);


        ParticleSystem particleSystem = particleExp.GetComponent<ParticleSystem>();
        particleExp.transform.localScale = new Vector3(3 * radius, 3 * radius, 3 * radius);
        if (particleSystem != null)
        {
            ParticleSystem.MainModule mainModule = particleSystem.main;
            mainModule.startSize = new ParticleSystem.MinMaxCurve(12 * radius, 30 * radius);
        }
        particleExp.transform.GetChild(3).GetComponent<ParticleSystem>().Play();
        GameObject particleFire = Instantiate(particleFireWork, transform.position, Quaternion.identity);
        particleFire.GetComponent<ParticleSystem>().Play();
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