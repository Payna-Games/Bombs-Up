using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodLens : MonoBehaviour
{
    [SerializeField] private GameObject[] woods;
    [SerializeField] private GameObject radius;
    [SerializeField] private Collider[] woodColliders;
    [SerializeField] private ParticleSystem woodParticle;
    [SerializeField] private float explosionForce = 100.0f; 
    [SerializeField] private float explosionRadius = 0.1f;
    private int i;
    private int d;
    private bool destroy;
    private int groupIndex;
    private int collidersPerGroup;
    void Start()
    {
        i = 0;
        d = 0;
        groupIndex = 0;
        collidersPerGroup = 4;
        EnableNextGroupOfColliders();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            if (i < 5)
            {
                destroy = false;
                Instantiate(woodParticle, woods[i].transform.position+new Vector3(0f,0.5f,0f) , Quaternion.identity);
                Explode(i);
                StartCoroutine(DestroyPieces());
                i++; 
                Destroy(other.gameObject);
            }
            
        }
        
    }


    private void Explode(int j)
    {
        
        destroy = false;
        Vector3 explosionPosition = radius.transform.position;
        //woods[j].transform.position;
        EnableNextGroupOfColliders();
        //woodsSetActive[j].SetActive(true);
        //woodColliders[j].enabled = true;

        
            string targetTag = "WoodPieces";

            
            Collider[] allColliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

            
            Collider[] colliders = System.Array.FindAll(allColliders, col => col.CompareTag(targetTag));

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 1.0F);
                }
            }
        
      

    }
    void Update()
    {

        if (destroy)
        {
            Destroy(woods[d].gameObject);
        }

        
    }
    private IEnumerator DestroyPieces()
    {
        yield return new WaitForSeconds(1f);
        destroy = true;
        if (d < 5)
        {
            d++; 
        }
        


    }
    void EnableNextGroupOfColliders()
    {
        
        int startIndex = groupIndex * collidersPerGroup;
        int endIndex = startIndex + collidersPerGroup;

        for (int c = startIndex; c < endIndex && c < woodColliders.Length; c++)
        {
            woodColliders[c].enabled = true;
        }

        groupIndex++;

        if (startIndex >= woodColliders.Length)
        {
            
            groupIndex = 0;
        }
    }
}
