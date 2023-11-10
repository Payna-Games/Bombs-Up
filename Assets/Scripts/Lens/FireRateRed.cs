using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireRateRed : MonoBehaviour
{
    [SerializeField] private int addFireRate;
        [SerializeField] private TextMeshProUGUI fireRateText;
        [SerializeField] private ParticleSystem waterParticle;
        [SerializeField] private Transform particleTransform;
        [SerializeField] private Renderer myRenderer;
        [SerializeField] private Material greenMaterial;
        
    
        
         
    
    
        private void Start()
        {
            if ( addFireRate < 0)
            {
                fireRateText.text =   addFireRate.ToString(); 
            }
            else if ( addFireRate == 0)
            {
                fireRateText.text =   addFireRate.ToString(); 
            }
            else
            {
                fireRateText.text = "+" +  addFireRate.ToString(); 
            }
            
            
        }
    
        
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MiniBomb"))
            {
                addFireRate++;
                if (addFireRate < 0)
                {
                    fireRateText.text =  addFireRate.ToString(); 
                }
                else if ( addFireRate == 0)
                {
                    fireRateText.text =   addFireRate.ToString(); 
                    myRenderer.material = greenMaterial;
                }
                
                else if( addFireRate>0)
                {
                    
                    fireRateText.text = "+" +  addFireRate.ToString(); 
                }
                
                
                Instantiate(waterParticle, particleTransform.position, Quaternion.identity);
                waterParticle.Play();
                Destroy(other.gameObject);
                TextScaleUpAnim.TextScaleUp(fireRateText);
                
            }
    
            if (other.CompareTag("Bomb"))
            {
                if( addFireRate !=0)
                {
                    waterParticle.Stop();
                    MiniBompManager.miniBompManager.range +=  addFireRate*10;
                    StartCoroutine(CloseLensAnim());
                    
                }
                else if (addFireRate == 0)
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
