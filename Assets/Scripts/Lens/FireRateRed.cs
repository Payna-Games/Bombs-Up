using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireRateRed : MonoBehaviour
{
    [SerializeField] private int addFireRate;
    [SerializeField] private TextMeshProUGUI fireRateText;
    [SerializeField] private Transform particleTransform;
    [SerializeField] private Renderer myRenderer;
    [SerializeField] private Material greenMaterial;
    private bool savedLens = false;





    private void Start()
    {
        if (addFireRate < 0)
        {
            fireRateText.text = addFireRate.ToString();
        }
        else if (addFireRate == 0)
        {
            fireRateText.text = addFireRate.ToString();
        }
        else
        {
            fireRateText.text = "+" + addFireRate.ToString();
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRate++;
            if (addFireRate < 0)
            {
                fireRateText.text = addFireRate.ToString();
            }
            else if (addFireRate == 0)
            {
                fireRateText.text = addFireRate.ToString();
                myRenderer.material = greenMaterial;
            }

            else if (addFireRate > 0)
            {

                fireRateText.text = "+" + addFireRate.ToString();
            }


            CreateParticle.Create(transform.position);
            savedLens = true;
            Destroy(other.gameObject);
            TextScaleUpAnim.TextScaleUp(fireRateText);

        }

        if (other.CompareTag("Bomb"))
        {
            
            if (addFireRate != 0 && !LensWaitTime.LensW.lensActive)
            {
                LensWaitTime.LensW.lensActive = true;
                LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
                CreateParticle.ParticleTransform.gameObject.SetActive(false);
               
                float clampedValue = Mathf.Clamp(1 - addFireRate / 50f, 0.2f, 1.5f);
                MiniBompManager.miniBompManager.spawnSpeed = clampedValue;

                
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
