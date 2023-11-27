using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRange : MonoBehaviour
{
    [SerializeField] private int addFireRange;
    [SerializeField] private TextMeshProUGUI fireRangeText;
    [SerializeField] private Transform particleTransform;
    private bool savedLens = false;
    
    
    

    private void Start()
    {
        if (addFireRange == 0)
        {
            fireRangeText.text =  addFireRange.ToString(); 
        }
        else
        {
            fireRangeText.text = "+" + addFireRange.ToString(); 
        }

      
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRange++;
            if (addFireRange == 0)
            {
                fireRangeText.text =  addFireRange.ToString(); 
                TextScaleUpAnim.TextScaleUp(fireRangeText);
            }
            else
            {
                fireRangeText.text = "+" + addFireRange.ToString(); 
                TextScaleUpAnim.TextScaleUp(fireRangeText);
            }

            CreateParticle.Create(transform.position);
            savedLens = true;
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Bomb"))
        {
            
            if(addFireRange !=0 &&  !LensWaitTime.LensW.lensActive)
            {
                 LensWaitTime.LensW.lensActive = true;
                 LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                
               
                MiniBompManager.miniBompManager.range += addFireRange*10;
                
                
                savedLens = false;
                gameObject.SetActive(false);
                
            }
            
        }
    }

    private void Update()
    {
        if (savedLens)
        {
            CreateParticle.GetLensPosition(transform.position);
            StartCoroutine(SavedLens());
        }
       
    }
    private IEnumerator SavedLens()
    {
        yield return new WaitForSeconds(1f);
        savedLens = false;

    }
}


