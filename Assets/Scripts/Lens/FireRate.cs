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

        fireRateStop = false;
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
           
            if (addFireRateText != 0 && !LensWaitTime.lensW.lensActive )
            {
                bombTagActive = true;
                
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                LensWaitTime.lensW.lensActive = true;
                
               
              
                
               
                
                 
                LensWaitTime.lensW.StartCoroutine(LensWaitTime.lensW.LensActive());
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
            Debug.Log( "spawnSpeed" + MiniBompManager.miniBompManager.spawnSpeed);
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
