using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    [SerializeField] private StarCalculate starCalculate;

    private float starRatee;
  // public event Action<float> killCount; 
  
   public void StarCountt ()
   {

       starRatee = starCalculate.starRate;
       
       if (starRatee <= 0.33f)
       {
           
           transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
       }
       
       if (0.33f< starRatee && starRatee <=0.66f)
       {
           
           transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
           transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
           
       }
       if (0.66f< starRatee && starRatee < 100f)
       {
           transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
           transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
           transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
           
       }
       

   }
}
