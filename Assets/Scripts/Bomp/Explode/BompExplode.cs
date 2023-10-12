using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BompExplode : ExplodeCalculate
{
    public event Action<GameObject> explode;
    public event Action<int> explodeCount;
    public event Action explodeBefor;
    public int cityCount = 0;
    public List<GameObject> checkList;

    public CameraVibration cameraVibration;

    public List<GameObject> ActiveObject;
    public float explosionForce = 10000f;
    public float explosionRadius = 100f;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && (collision.gameObject.CompareTag("City") || collision.gameObject.CompareTag("Ground")))
        {
            explode?.Invoke(collision.gameObject);
            transform.GetComponent<Rigidbody>().drag = 1f;
            Explode();
            hasCollided = true;
            cameraVibration.StartVibration();
            StartCoroutine(Wait2(0.2f));
        }
    }


    private void Explode()
    {
        explosionRadius = RadiusExplode();
        explosionForce = ForceExplode();
        Collider[] explodeObject = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider item in explodeObject)
        {
            if (item.gameObject.CompareTag("Explode"))
            {
                item.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
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
        foreach (GameObject item in ActiveObject)
        {
            item.SetActive(true);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        explodeBefor?.Invoke();
        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("Pieces") && !checkList.Contains(col.gameObject))
            {
                checkList.Add(col.gameObject);
                Rigidbody rb = col.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    cityCount++;
                    rb.mass = 1;
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);
                }
            }
        }
        StartCoroutine(Wait3(checkList));


        explodeCount?.Invoke(cityCount);
    }
    IEnumerator Wait3(List<GameObject> cityObj)
    {
        yield return new WaitForSeconds(0.2f);
        foreach (GameObject item in checkList)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
