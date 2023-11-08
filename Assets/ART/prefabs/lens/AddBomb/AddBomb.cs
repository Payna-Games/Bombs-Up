using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class AddBomb : MonoBehaviour
{

    [SerializeField] private ParticleSystem waterParticle;
    [SerializeField] private Transform particleTransform;

    [SerializeField]  private Image rocketImage;
    [SerializeField] private float fillAmountValue;
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {

            rocketImage.fillAmount += fillAmountValue;
            
            
            Instantiate(waterParticle, particleTransform.position, Quaternion.identity);
            waterParticle.Play();
            Destroy(other.gameObject);
            
        }

        if ((other.CompareTag("Bomb")&& rocketImage.fillAmount ==1 ))
        {

           
            for (int i = 0; i < other.transform.GetChild(4).childCount; i++)
                {
                    if (!other.transform.GetChild(4).GetChild(i).gameObject.activeSelf)
                    {
                        other.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                        other.transform.GetComponent<KiloTonCalculate>().Calculate();
                        break;
                    }
                }
                StartCoroutine(CloseLensAnim());
        }
        else if((other.CompareTag("Bomb")&& fillAmountValue !=1 ))
        {
                
            StartCoroutine(CloseLensAnim());
            
        }
    }
     
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}
