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
    private bool starAnim = false;
    private bool starAnim2 = false;
    private bool starAnim3 = false;
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


        Debug.Log("starRate: " + starRatee);
        Debug.Log("star2: " + star2);
        Debug.Log("star3: " + star3);
        
        

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

            if (stars[0].fillAmount >= starRatee / 0.33f * (1 - tolerance) &&
                stars[0].fillAmount <= starRatee / 0.33f * (1 + tolerance))
            {
                starAnim = true;
                if (starBool)
                {
                    fillUpdate1 = false;

                    starAnim = false;

                }
                
                

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
                    starAnim = true;
                    if (starBool)
                    {
                        Debug.Log("1");
                        starAnim = false;
                        fullTheAmount2= true;
                        fullTheAmount1 = false;
                        
                        
                    }
                }
                else if(star2 <0.33f)
                {
                    starAnim = true;
                    if (starBool)
                    {
                        starAnim = false;
                    }
                    
                    
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
                starAnim2 = true;
                if (starBool)
                {
                    starAnim = false;
                    fillUpdate2 = false;
                }
            }

        }

        if (fullTheAmount2)
        {
            fill1 = Mathf.Lerp(0, 1, Time.deltaTime * 1);
            stars[1].fillAmount += fill1;
            Debug.Log("2");

            if (stars[1].fillAmount == 1)
            {
                Debug.Log("3");
                
                if (star3 >= 0.33 )
                {
                    Debug.Log("fullTheAmount3");
                    starAnim2 = true;
                    if (starBool)
                    {
                        starAnim2 = false;
                        fullTheAmount3 = true;
                        fullTheAmount2 = false;
                       
                    }
                }
                else if(star3 <0.33f )
                {
                    Debug.Log("fillUpdate3");
                    starAnim2 = true;
                    if (starBool)
                    {
                        starAnim2 = false;
                        fillUpdate3 = true;
                        fullTheAmount2 = false;
                       
                    }
                    
                }


            }
        }

        if (fillUpdate3)
        {
            fill2 = Mathf.Lerp(0, star3 / 0.33f, Time.deltaTime * 1);
            stars[2].fillAmount += fill2;

            if (stars[3].fillAmount >= star3 / 0.33f * (1 - tolerance) &&
                stars[2].fillAmount <= star3 / 0.33f * (1 + tolerance))
            {

                fillUpdate3 = false;
                StarAnim(5);
                if (starBool)
                {
                    starAnim3 = false;
                   
                }
            }

        }

        if (fullTheAmount3)
        {
            fill2 = Mathf.Lerp(0, 1, Time.deltaTime * 1);
            stars[2].fillAmount += fill2;

            if (stars[2].fillAmount == 1)

            {
                starAnim3 = true;
                StarAnim(5);
                if (starBool)
                {
                    starAnim3 = false;
                    fullTheAmount3 = false;
                }
                


            }
        }

        if (starAnim)
        {
            starBool = false;
            StarAnim(3);
            



        }
        if (starAnim2 )
        {
            starBool = false;
            StarAnim(4);
            
            
        }
        if (starAnim3 )
        {
            starBool = false;
            StarAnim(5);
            
            
            
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
