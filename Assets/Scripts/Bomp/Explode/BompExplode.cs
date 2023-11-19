using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vector3 = System.Numerics.Vector3;

public class BompExplode : ExplodeCalculate
{
    [SerializeField] private CityExplodeParticle cityExplodeParticle;
    public event Action<GameObject> explode;
    public event Action<int> explodeCount;
    public event Action explodeBefor;
    public int cityCount = 0;
    public List<GameObject> checkList;

    public CameraVibration cameraVibration;

    public float explosionForce = 10000f;
    public float explosionRadius = 100f;
    private bool hasCollided = false;

    public bool onVibrator = true;

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
                Vibrator.Vibrate(200);
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
        Explode2();
    }

    IEnumerator Wait2(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }


    private void Explode2()
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
                    //cityCount++;
                    //rb.mass = 1;
                    //rb.isKinematic = false;
                    //rb.useGravity = true;
                    //rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);
                }
            }
        }
        //StartCoroutine(Wait3());
    }
    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(0.2f);
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
        explodeCount?.Invoke(cityCount);
    }

    
}
