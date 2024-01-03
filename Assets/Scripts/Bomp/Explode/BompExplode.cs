using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.UI;
using DG.Tweening;
using YsoCorp.GameUtils;

public class BompExplode : ExplodeCalculate
{
    [SerializeField] private CityExplodeParticle cityExplodeParticle;
    
    
    public event Action<GameObject> explode;
    public event Action<int> explodeCount;
    public event Action explodeBefor;
    public int cityCount = 0;
    public List<GameObject> checkList;
    public CameraVibration cameraVibration;

    public float explosionForce = 13f;
    public float explosionRadius = 100f;
    private bool hasCollided = false;

    public bool onVibrator = true;

    private void Start()
    {
        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            Debug.Log("OLD");
        }
        if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            Debug.Log("NEW");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && (collision.gameObject.CompareTag("City") || collision.gameObject.CompareTag("Ground")))
        {
            explode?.Invoke(collision.gameObject);
            transform.GetComponent<Rigidbody>().drag = 1f;
            Explode();
            cityExplodeParticle?.CreateCityParticle();
            StartCoroutine(Wait3());
            hasCollided = true;
            cameraVibration.StartVibration();
            StartCoroutine(Wait2(0.2f));
            if (VibratorManager.vibratorManager.mainVibrator)
            {
                Vibrator.Vibrate();
                Vibrator.Vibrate(75);
            }
        }
    }


    private void Explode()
    {
       
        explosionRadius = RadiusExplode();
        
        explosionForce = ForceExplode();
        StartCoroutine(Wait(0.1f));
    }

    IEnumerator Wait(float sure)
    {
        yield return new WaitForSeconds(sure);
       // Explode2(explosionRadius);
    }

    IEnumerator Wait2(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }


    private void Explode2(float explosionRadius)
    {

       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
       
        explodeBefor?.Invoke();
        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("City") && !checkList.Contains(col.gameObject))
            {
                checkList.Add(col.gameObject);
                Rigidbody rb = col.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    col.gameObject.GetComponent<Renderer>().enabled = false;
                    Destroy(rb);
                    col.enabled = false;
                    col.transform.GetChild(0).gameObject.SetActive(true);
                    
                }
            }
        }
        
    }
    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(0.2f);
        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            Explode2(explosionRadius);
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Pieces");

            foreach (GameObject obj in objectsWithTag)
            {
                if (obj.GetComponent<Rigidbody>() != null)
                {
                    cityCount++;
                    Vector3 explodeDirection = new Vector3(0, 1, 0);
                    obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);

                }
            }
            //Debug.Log("objectswithtag: " + objectsWithTag.Length);
            explodeCount?.Invoke(cityCount);
        }
        else if(YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            Explode2(explosionRadius);



            if (KiloTonCalculate.kiloTonCalculate.KiloTon < Kill.kill.maxObj)
            {
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Pieces");

                foreach (GameObject obj in objectsWithTag)
                {
                    if (obj.GetComponent<Rigidbody>() != null)
                    {
                        cityCount++;
                        Vector3 explodeDirection = new Vector3(0, 1, 0);
                        obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);




                    }
                }
            }
            else if (KiloTonCalculate.kiloTonCalculate.KiloTon >= Kill.kill.maxObj)
            {
                Explode2(250);

                GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("Pieces");
                foreach (GameObject obj in objectsWithTag2)
                {
                    if (obj.GetComponent<Rigidbody>() != null)
                    {

                        cityCount++;
                        Vector3 explodeDirection = new Vector3(0, 1, 0);
                        obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 250, 10, ForceMode.Impulse);




                    }
                }
            }


            explodeCount?.Invoke(cityCount);





        }
        else
        {
            Explode2(explosionRadius);



            if (KiloTonCalculate.kiloTonCalculate.KiloTon < Kill.kill.maxObj)
            {
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Pieces");

                foreach (GameObject obj in objectsWithTag)
                {
                    if (obj.GetComponent<Rigidbody>() != null)
                    {
                        cityCount++;
                        Vector3 explodeDirection = new Vector3(0, 1, 0);
                        obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);




                    }
                }
            }
            else if (KiloTonCalculate.kiloTonCalculate.KiloTon >= Kill.kill.maxObj)
            {
                Explode2(250);

                GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("Pieces");
                foreach (GameObject obj in objectsWithTag2)
                {
                    if (obj.GetComponent<Rigidbody>() != null)
                    {

                        cityCount++;
                        Vector3 explodeDirection = new Vector3(0, 1, 0);
                        obj.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 250, 10, ForceMode.Impulse);




                    }
                }
            }


            explodeCount?.Invoke(cityCount);





        }
    }
    
   
     

      

    
}
