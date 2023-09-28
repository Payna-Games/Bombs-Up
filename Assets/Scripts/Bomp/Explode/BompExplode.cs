using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BompExplode : MonoBehaviour
{
    public event Action<GameObject> explode;
    public event Action<int> explodeCount;
    public int cityCount = 0;
    public List<GameObject> checkList;

    public GameObject againButton;
    public float explosionForce = 10000f;
    public float explosionRadius = 100f;
    public GameObject crater;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("City") || collision.gameObject.CompareTag("Ground"))
        {
            explode?.Invoke(collision.gameObject);

            Explode();
            gameObject.SetActive(false);
        }
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("City")&&!checkList.Contains(col.gameObject))
            {
                checkList.Add(col.gameObject);
                Debug.Log(col.gameObject.name);
                Rigidbody rb = col.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    cityCount++;
                    rb.isKinematic = false;
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);
                    rb.useGravity = true;
                    rb.drag = 0.5f;
                }                
            }            
        }
        explodeCount?.Invoke(cityCount);
        Vector3 creadedPos = new Vector3(transform.position.x, -802, transform.position.z);
        GameObject createdCrater = Instantiate(crater, creadedPos, Quaternion.identity);
        createdCrater.transform.localScale = new Vector3(explosionRadius / 50, explosionRadius / 50, explosionRadius / 50);
        againButton.SetActive(true);
    }
}
