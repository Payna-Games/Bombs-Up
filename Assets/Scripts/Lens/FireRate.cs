using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRate : MonoBehaviour
{
    [SerializeField] private int addFireRateText;
    [SerializeField] private Transform particleTransform;
    [SerializeField] private TextMeshProUGUI fireRateText;
    private bool savedLens = false;
    private bool fireRateStop;

    private void Start()
    {
       
        if (addFireRateText == 0)
        {
            fireRateText.text =  addFireRateText.ToString();
        }
        else
        {
            fireRateText.text = "+" + addFireRateText.ToString();
        }

        fireRateStop = false;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRateText++;
           
            if (addFireRateText == 0)
            {
                fireRateText.text =  addFireRateText.ToString();
            }
            else
            {
                fireRateText.text = "+" + addFireRateText.ToString();
            }
            
            CreateParticle.Create(transform.position);
            savedLens = true;
           
            
            TextScaleUpAnim.TextScaleUp(fireRateText);
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Bomb"))
        {
           
            if (addFireRateText != 0 && !LensWaitTime.lensW.lensActive )
            {
                
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                LensWaitTime.lensW.lensActive = true;
                

                if (!fireRateStop)
                {
                    MiniBompManager.miniBompManager.spawnSpeed -= addFireRateText / 50f;
                }
                 
                LensWaitTime.lensW.StartCoroutine(LensWaitTime.lensW.LensActive());
                savedLens = false;
                gameObject.SetActive(false);
                
                
            }
            
        }
    }

    private void Update()
    {
        
        if (savedLens )
        {
            CreateParticle.GetLensPosition(transform.position);
            StartCoroutine(SavedLens());
        }
        if(MiniBompManager.miniBompManager.spawnSpeed <=0.2f || MiniBompManager.miniBompManager.spawnSpeed >=1.5f )
        {
            fireRateStop = true;
        }
       
    }

    private IEnumerator SavedLens()
    {
        yield return new WaitForSeconds(2.5f);
        savedLens = false;
    
    }

    
    
}
