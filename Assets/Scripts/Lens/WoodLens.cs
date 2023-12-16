using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class WoodLens : MonoBehaviour
{
    [SerializeField] private GameObject[] woods;
    [SerializeField] private GameObject radius;
    [SerializeField] private Collider[] woodColliders;
    [SerializeField] private ParticleSystem woodParticle;
    [SerializeField] private float explosionForce = 100.0f; 
    [SerializeField] private float explosionRadius = 0.1f;

    [SerializeField] private float targetPosition;

    private bool hit;
    //[SerializeField] private BombLeftRight bombLeftRight;

    // [SerializeField] private Vector3 forceDirection;
    // [SerializeField] private float forceMagnitude = 10.0f;
    // public bool collisions;
    private int i;
    private int d;
    private bool destroy = false;
    
    private int groupIndex;
    private int collidersPerGroup;
    void Start()
    {
        i = 0;
        d = 0;
        groupIndex = 0;
        collidersPerGroup = 4;
        hit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            if (i <= 5)
            {
                Debug.Log("i = " + i);
                
                Instantiate(woodParticle, woods[i].transform.position+new Vector3(0f,0.5f,0f) , Quaternion.identity);
                Explode(i);
                StartCoroutine(DestroyPieces());
                
                Destroy(other.gameObject);
                i++; 
                
            }
            
        }
        if (other.CompareTag("Bomb") && !hit && i<5)
        {
            if (!LensWaitTime.LensW.lensActive)
            {
                other.transform.DOMoveY(other.transform.position.y+targetPosition, 0.5f).SetEase(Ease.InBack);
                hit = true;
                
                LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
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

        if (destroy )
        {
            Destroy(woods[d].gameObject);
            
            int lastNumber = woods.Length - 1;
            
            if (d == lastNumber-1)
            {
                Destroy(woods[lastNumber]);
               // Debug.Log("update1");
            }

            d++;
            destroy = false;
           // Debug.Log("update2");
        }

    }
    private IEnumerator DestroyPieces()
    {
        
        yield return new WaitForSeconds(0.7f);
        destroy = true;
        
           // Debug.Log("d"+ d);

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
