using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRate : MonoBehaviour
{
    [SerializeField] private int addFireRateText;
        [SerializeField] private ParticleSystem waterParticle;
        [SerializeField] private Transform particleTransform;
    //[SerializeField] private int fireRate;
    [SerializeField] private TextMeshProUGUI fireRateText;
    
    

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
            Destroy(other.gameObject);
            //ParticleSystem newParticle = Instantiate(waterParticle, particleTransform.position, Quaternion.identity);
            CreateParticle.Create(transform.position);
            waterParticle.Play();
            TextScaleUpAnim.TextScaleUp(fireRateText);
            
        }

        if (other.CompareTag("Bomb"))
        {
            if (addFireRateText != 0 && !LensWaitTime.lensW.lensActive )
            {
                LensWaitTime.lensW.lensActive = true;
                float clampedValue = Mathf.Clamp(1-addFireRateText/50f,0.2f,1.5f);
                MiniBompManager.miniBompManager.spawnSpeed = clampedValue;
                LensWaitTime.lensW.StartCoroutine(LensWaitTime.lensW.LensActive());
                gameObject.SetActive(false);
                
            }
            
        }
    }

    private void Update()
    {
        waterParticle.transform.position = transform.position;
    }
}
