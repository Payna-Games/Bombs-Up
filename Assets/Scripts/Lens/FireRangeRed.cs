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
    

    
     


    private void Start()
    {
        if (addFireRange < 0)
        {
            fireRangeText.text =  addFireRange.ToString(); 
        }
        else if (addFireRange == 0)
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
            if (addFireRange < 0)
            {
                fireRangeText.text =   addFireRange.ToString(); 
            }
            else if (addFireRange == 0)
            {
                fireRangeText.text =  addFireRange.ToString(); 
            }
            
            else if(addFireRange>0)
            {
                myRenderer.material = greenMaterial;
                fireRangeText.text = "+" + addFireRange.ToString(); 
            }
            
            
            Instantiate(waterParticle, particleTransform.position, Quaternion.identity);
            waterParticle.Play();
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Bomb"))
        {
            if(addFireRange !=0)
            {
                waterParticle.Stop();
                MiniBompManager.miniBompManager.range += addFireRange*10;
                StartCoroutine(CloseLensAnim());
                
            }
            else if (addFireRange== 0)
            {
                waterParticle.Stop();
                StartCoroutine(CloseLensAnim());
            }
            
        }
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}