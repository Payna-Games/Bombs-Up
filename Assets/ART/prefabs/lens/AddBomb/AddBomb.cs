using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class AddBomb : MonoBehaviour
{

    [SerializeField] private ParticleSystem waterParticle;
    [SerializeField] private Transform particleTransform;

    [SerializeField]  private Image rocketImage;
    [SerializeField] private float fillAmountValue;
    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float targetScale = 1.5f;
    [SerializeField] private float duration = 1f;
    private bool savedLens = false;
    public bool addBombLens;
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {

            rocketImage.fillAmount += fillAmountValue;
            
            
            CreateParticle.Create(transform.position);
            savedLens = true;
            Destroy(other.gameObject);
            
        }

        if ((other.CompareTag("Bomb")&& rocketImage.fillAmount ==1 ))
        {

            CreateParticle.ParticleTransform.gameObject.SetActive(false);
            for (int i = 0; i < other.transform.GetChild(4).childCount; i++)
                {
                    if (!other.transform.GetChild(4).GetChild(i).gameObject.activeSelf)
                    {
                        GameObject clone = other.transform.GetChild(4).GetChild(i).gameObject;
                        clone.SetActive(true);
                        other.transform.GetChild(4).GetChild(i).DOScale(Vector3.one*targetScale,0.2f).SetEase(Ease.Linear).OnComplete(() =>
                        {

                            clone.transform.DOScale(Vector3.one* initialScale, duration)
                                .SetEase(Ease.InBounce);

                        });
                       // clone.transform.GetChild(0).GetComponent<KiloTonCalculate>().Calculate();
                       addBombLens = true;
                        break;
                    }
                }

           
            gameObject.SetActive(false);
        }
        else if((other.CompareTag("Bomb")&& fillAmountValue !=1 ))
        {
                
            gameObject.SetActive(false);
            
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
