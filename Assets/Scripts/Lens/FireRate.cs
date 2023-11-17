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
    //[SerializeField] private int fireRate;
    [SerializeField] private TextMeshProUGUI fireRateText;
    private bool savedLens = false;
    

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
                LensWaitTime.lensW.lensActive = true;
                float clampedValue = Mathf.Clamp(1-addFireRateText/25f,0.2f,1.5f);
                MiniBompManager.miniBompManager.spawnSpeed = clampedValue;
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
       
    }

    private IEnumerator SavedLens()
    {
        yield return new WaitForSeconds(2.5f);
        savedLens = false;
    
    }

    
    
}
