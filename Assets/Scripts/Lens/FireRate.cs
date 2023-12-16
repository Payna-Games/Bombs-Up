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
    
    public bool bombTagActive;

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

        
        bombTagActive = false;
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
           
            if (addFireRateText != 0 && !LensWaitTime.LensW.lensActive )
            {
                LensWaitTime.LensW.lensActive = true;
                LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
                bombTagActive = true;
                
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                
                
               
              
                
               
                
                 
                
                savedLens = false;
               
                
                
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

        if (bombTagActive)
        {
            
            MiniBompManager.miniBompManager.spawnSpeed -= addFireRateText / 40f;
            MiniBompManager.miniBompManager.spawnSpeed = Mathf.Clamp(MiniBompManager.miniBompManager.spawnSpeed, 0.2f, 1.5f);
            gameObject.SetActive(false);
            bombTagActive = false;

        }
        
        

    }

    private IEnumerator SavedLens()
    {
        yield return new WaitForSeconds(2.5f);
        savedLens = false;
    
    }

    
    
}
