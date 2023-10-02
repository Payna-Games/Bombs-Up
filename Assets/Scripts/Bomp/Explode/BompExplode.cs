using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BompExplode : ExplodeCalculate
{
    public event Action<GameObject> explode;
    public event Action<int> explodeCount;
    public int cityCount = 0;
    public List<GameObject> checkList;


    public GameObject againButton;
    public float explosionForce = 10000f;
    public float explosionRadius = 100f;
    public GameObject crater;
    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && (collision.gameObject.CompareTag("City") || collision.gameObject.CompareTag("Ground")))
        {
            explode?.Invoke(collision.gameObject);
            transform.GetComponent<Rigidbody>().drag = 1f;
            Explode();

            hasCollided = true;
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

    private void Explode2()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("City") && !checkList.Contains(col.gameObject))
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
        explodeCount?.Invoke(cityCount);
        againButton.SetActive(true);
    }
}
