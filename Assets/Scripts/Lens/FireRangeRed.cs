using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRangeRed : MonoBehaviour
{
    [SerializeField] private int addFireRange;
    [SerializeField] private TextMeshProUGUI fireRangeText;
    [SerializeField] private ParticleSystem waterParticle;
    [SerializeField] private Transform particleTransform;
    [SerializeField] private Renderer myRenderer;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private int maxRange;
    [SerializeField] private int minRange;
    private bool savedLens = false;


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
            waterParticle.Play();
            TextScaleUpAnim.TextScaleUp(fireRangeText);
            Destroy(other.gameObject);

        }

        if (other.CompareTag("Bomb"))
        {
            if (addFireRange != 0 && !LensWaitTime.lensW.lensActive)
            {
                LensWaitTime.lensW.lensActive = true;
                waterParticle.Stop();
                int clampedValue = Mathf.Clamp(70 + addFireRange * 10, minRange, maxRange);
                MiniBompManager.miniBompManager.range = clampedValue;


            }
            else if (addFireRange == 0)
            {
                waterParticle.Stop();

            }

            LensWaitTime.lensW.StartCoroutine(LensWaitTime.lensW.LensActive());
            gameObject.SetActive(false);

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