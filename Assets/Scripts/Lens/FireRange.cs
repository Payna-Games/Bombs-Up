using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRange : MonoBehaviour
{
    [SerializeField] private int addFireRange;
    [SerializeField] private TextMeshProUGUI fireRangeText;
    [SerializeField] private ParticleSystem waterParticle;
    [SerializeField] private Transform particleTransform;
    
    
    

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
            
        }
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
    
}


