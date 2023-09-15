using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompExplode : MonoBehaviour
{
    public float explosionForce = 10000f;
    public float explosionRadius = 100f;
    public GameObject crater;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("City") || collision.gameObject.CompareTag("Ground"))
        {
            Explode();
            gameObject.SetActive(false);
        }
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("City"))
            {
                Debug.Log(col.gameObject.name);
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.constraints = RigidbodyConstraints.None;
                    rb.useGravity = true;
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 10, ForceMode.Impulse);
                }
            }
        }
        Vector3 creadedPos = new Vector3(transform.position.x, transform.position.y -9.6f, transform.position.z);
        GameObject createdCrater = Instantiate(crater,creadedPos,Quaternion.identity);
        createdCrater.transform.localScale = new Vector3(explosionRadius/50, explosionRadius/50, explosionRadius/50);
    }
}
