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
    
    private bool fillUpdate1 = false;
    private bool fillUpdate2 = false;
    private bool fillUpdate3 = false;
    private bool fullTheAmount1;
    private bool fullTheAmount2;
    private bool fullTheAmount3;
   
    public bool starBool = false;
    
    private float fill;
    private float fill1;
    private float fill2;
    private float star2;
    private float star3;
    private float starRatee;
    private float tolerance = 0.05f;


    void Awake()
    {
        DOTween.SetTweensCapacity(500, 50);
    }


    public void StarCountt()
    {

        starRatee = starCalculate.starRate;
        star2 = starRatee - 0.33f;
        star3 = star2 - 0.33f;


       
        
        

        if (starRatee < 0.33f)
        {
            fillUpdate1 = true;
        }
        else if (starRatee >= 0.33f)
        {
            fullTheAmount1 = true;
        }

    }



    private void Update()
    {
        if (fillUpdate1)
        {
            fill = Mathf.Lerp(0, starRatee / 0.33f, Time.deltaTime * 1f);
            stars[0].fillAmount += fill;

            if (stars[0].fillAmount >= starRatee / 0.33f * (1 - tolerance) && stars[0].fillAmount <= starRatee / 0.33f * (1 + tolerance))
            {
                StarAnim(3);
                fillUpdate1 = false;
                

            }

        }

        if (fullTheAmount1)
        {
            fill = Mathf.Lerp(0, 1, Time.deltaTime * 1f);
            stars[0].fillAmount += fill;

            if (stars[0].fillAmount == 1)
            {

                if (star2 >= 0.33f)
                {
                    StarAnim(3);
                    fullTheAmount2 = true;
                    fullTheAmount1 = false;
                  
                }
                else if(star2 <0.33f)
                {
                    StarAnim(3);
                    fillUpdate2 = true;
                    fullTheAmount1 = false;

                }



            }
        }

        if (fillUpdate2)
        {
            fill1 = Mathf.Lerp(0, star2 / 0.33f, Time.deltaTime * 1);
            stars[1].fillAmount += fill1;

            if (stars[1].fillAmount >= star2 / 0.33f * (1 - tolerance) &&
                stars[1].fillAmount <= star2 / 0.33f * (1 + tolerance))
            {
               StarAnim(4);
               fillUpdate2 = false;
            }

        }

        if (fullTheAmount2)
        {
            fill1 = Mathf.Lerp(0, 1, Time.deltaTime * 1);
            stars[1].fillAmount += fill1;
           

            if (stars[1].fillAmount == 1)
            {
                
                
                if (star3 >= 0.33 )
                {
                    StarAnim(4);
                    fullTheAmount3 = true;
                    fullTheAmount2 = false;
                    
                }
                else if(star3 <0.33f )
                {
                    StarAnim(4);
                    fillUpdate3 = true;
                    fullTheAmount2 = false;
                    
                }


            }
        }

        if (fillUpdate3)
        {
            fill2 = Mathf.Lerp(0, star3 / 0.33f, Time.deltaTime * 1);
            stars[2].fillAmount += fill2;

            if (stars[2].fillAmount >= star3 / 0.33f * (1 - tolerance) &&
                stars[2].fillAmount <= star3 / 0.33f * (1 + tolerance))
            {

                StarAnim(5);
                fillUpdate3 = false;
            }

        }

        if (fullTheAmount3)
        {
            fill2 = Mathf.Lerp(0, 1, Time.deltaTime * 1);
            stars[2].fillAmount += fill2;

            if (stars[2].fillAmount == 1)

            {
                StarAnim(5);
                fullTheAmount3 = false;



            }
        }

       

    }
    private void StarAnim(int star )
    {
        stars[star].transform.DOScale(Vector3.one * 2.3f, 0.4f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                stars[star].transform.DOScale(Vector3.one * 1.9f, 0.4f)
                    .SetEase(Ease.OutBounce).OnComplete(() => { starBool = true; });
            });

    }
}
