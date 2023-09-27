using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BompExplode : MonoBehaviour
{
    public event Action<GameObject> explode;

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
            Debug.Log(col.gameObject.name);
            if (col.gameObject.CompareTag("City"))
            {

                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);
                }
            }
        }
        Vector3 creadedPos = new Vector3(transform.position.x, -802 , transform.position.z);
        GameObject createdCrater = Instantiate(crater,creadedPos,Quaternion.identity);
        createdCrater.transform.localScale = new Vector3(explosionRadius/50, explosionRadius/50, explosionRadius/50);
        againButton.SetActive(true);
    }
}
