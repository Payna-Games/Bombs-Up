using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    [SerializeField] private StarCalculate starCalculate;
    [SerializeField] private Image[] stars;
    [SerializeField] private bool fillAmountt1 = false;
    [SerializeField] private bool fillAmountt2 = false;
    [SerializeField] private bool fillAmountt3 = false;
    public float fill;
    public float fill1;
    public float fill2;
    private float star2;
    private float star3;
    private float starRatee;
    private float tolerance = 0.05f;
  
  
   public void StarCountt ()
   {

       starRatee = starCalculate.starRate;
       
       Debug.Log("starRate"+starRatee);
       fillAmountt1 = true;
       
       

   }

   private void fillUpdate1()
   {
        if(starRatee < 0.33f)
        {
           fill = Mathf.Lerp(0, starRatee/0.33f,Time.deltaTime*0.7f);
           stars[0].fillAmount += fill;
           if (stars[0].fillAmount >= star2/0.33f * (1 - tolerance) && stars[0].fillAmount <= star2/0.33f * (1 + tolerance) )
           {
               fillAmountt2 = false;
               stars[3].transform.DOScale(Vector3.one*2.3f, 0.5f) .SetEase(Ease.Linear)
                   .OnComplete(() =>
                   {
                       stars[3].transform.DOScale(Vector3.one * 1.9f, 0.5f)
                           .SetEase(Ease.OutBounce);
                      
                   });
               
               
           }
          
        }
        else if (starRatee >= 0.33f) 
        {
           fill = Mathf.Lerp(0, 1,Time.deltaTime*0.7f);
           stars[0].fillAmount += fill;
           star2 = starRatee - 0.33f;
           
           if (stars[0].fillAmount == 1)
           {
               fillAmountt1 = false;
               stars[3].transform.DOScale(Vector3.one * 2.3f, 0.5f)
                   .SetEase(Ease.Linear)
                   .OnComplete(() =>
                   {
                       stars[3].transform.DOScale(Vector3.one * 1.9f, 0.5f)
                           .SetEase(Ease.OutBounce)
                           .OnComplete(() => 
                           {
                               fillAmountt2 = true;
                           });
                   });
              
           }
           
        }
    

    
   }
   private void fillUpdate2()
   {
       if(star2 < 0.33f)
       {
           fill1 = Mathf.Lerp(0, star2/0.33f,Time.deltaTime*0.7f);
           stars[1].fillAmount += fill1;
           if (stars[1].fillAmount >= star2/0.33f * (1 - tolerance) && stars[1].fillAmount <= star2/0.33f * (1 + tolerance) )
           {
               fillAmountt2 = false;
               stars[4].transform.DOScale(Vector3.one*2.3f, 0.5f) .SetEase(Ease.Linear)
                   .OnComplete(() =>
                   {
                       stars[4].transform.DOScale(Vector3.one * 1.9f, 0.5f)
                           .SetEase(Ease.OutBounce);
                      
                   });
               
               
           }
       }
       else if(star2 >= 0.33f)
       {
           fill1 = Mathf.Lerp(0, 1,Time.deltaTime*0.7f);
           stars[1].fillAmount += fill;
           star3 = star2 - 0.33f;
           
           if(stars[1].fillAmount == 1)
           stars[4].transform.DOScale(Vector3.one*2.3f, 0.5f) .SetEase(Ease.Linear)
               .OnComplete(() =>
               {
                   stars[4].transform.DOScale(Vector3.one * 1.9f, 0.5f)
                       .SetEase(Ease.OutBounce);
                   fillAmountt2 = false;
                   fillAmountt3 = true;
               });
          
       }
           
              
           
       
           
     
   }
   private void fillUpdate3()
   {
      
       if(star3 < 0.33f)
       {
           fill2 = Mathf.Lerp(0, star2/0.33f,Time.deltaTime*0.7f);
           stars[2].fillAmount += fill2;
           if (stars[2].fillAmount >= star2/0.33f * (1 - tolerance) && stars[2].fillAmount <= star2/0.33f * (1 + tolerance) )
           {
               fillAmountt2 = false;
               stars[5].transform.DOScale(Vector3.one*2.3f, 0.5f) .SetEase(Ease.Linear)
                   .OnComplete(() =>
                   {
                       stars[5].transform.DOScale(Vector3.one * 1.9f, 0.5f)
                           .SetEase(Ease.OutBounce);
                      
                   });
               
               
           }
          
       }
       if(star3 >=0.33f)
       {
           fill2 = Mathf.Lerp(0, 1,Time.deltaTime*0.7f);
           stars[2].fillAmount += fill;
           
           
           if(stars[1].fillAmount == 1)
               stars[4].transform.DOScale(Vector3.one*2.3f, 0.5f) .SetEase(Ease.Linear)
                   .OnComplete(() =>
                   {
                       stars[4].transform.DOScale(Vector3.one * 1.9f, 0.5f)
                           .SetEase(Ease.OutBounce);
                       fillAmountt2 = false;
                       fillAmountt3 = true;
                   });
           
       }
       
       
       
      
           
      
   }

   private void Update()
   {
       if (fillAmountt1)
       {
           fillUpdate1();

       }

       if (fillAmountt2)
       {
           fillUpdate2();
           Debug.Log("2");
           
       }
       if (fillAmountt3)
       {
           fillUpdate3();
         
       }
       
   }
}
