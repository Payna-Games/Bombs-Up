using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRangeRed : MonoBehaviour
{
    [SerializeField] private int addFireRange;
    [SerializeField] private TextMeshProUGUI fireRangeText;
    
    [SerializeField] private Transform particleTransform;
    [SerializeField] private Renderer myRenderer;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private int maxRange;
    [SerializeField] private int minRange;
    private bool savedLens = false;
    private bool bombTagActive;

    private void Start()
    {
        if (addFireRange < 0)
        {
            fireRangeText.text = addFireRange.ToString();
        }
        else if (addFireRange == 0)
        {
            fireRangeText.text = addFireRange.ToString();
        }
        else
        {
            fireRangeText.text = "+" + addFireRange.ToString();
        }
        bombTagActive = false;


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRange++;
            if (addFireRange < 0)
            {
                fireRangeText.text = addFireRange.ToString();

            }
            else if (addFireRange == 0)
            {
                fireRangeText.text = addFireRange.ToString();
                myRenderer.material = greenMaterial;
            }

            else if (addFireRange > 0)
            {

                fireRangeText.text = "+" + addFireRange.ToString();
            }


            CreateParticle.Create(transform.position);
            savedLens = true;
            TextScaleUpAnim.TextScaleUp(fireRangeText);
            Destroy(other.gameObject);

        }

        if (other.CompareTag("Bomb"))
        {
           
            if (addFireRange != 0 && !LensWaitTime.LensW.lensActive)
            {
                LensWaitTime.LensW.lensActive = true;
                LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
                
                bombTagActive = true;
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                
                
                int clampedValue = Mathf.Clamp(70 + addFireRange * 10, minRange, maxRange);
                
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
        if (bombTagActive)
        {
            Debug.Log( "spawnSpeed" + MiniBompManager.miniBompManager.spawnSpeed);
            MiniBompManager.miniBompManager.range -= addFireRange;
            MiniBompManager.miniBompManager.range = Mathf.Clamp( MiniBompManager.miniBompManager.range, 100, 250);
            gameObject.SetActive(false);
            bombTagActive = false;

        }

    }

    private IEnumerator SavedLens()
    {
        yield return new WaitForSeconds(1f);
        savedLens = false;

    }
}