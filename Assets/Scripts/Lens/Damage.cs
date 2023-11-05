using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
   // [SerializeField] private int addDamage;
    [SerializeField] private TextMeshProUGUI damageText;
    private ObjectLevel headObjectLevel;
    private ObjectLevel bodyObjectLevel;
    private ObjectLevel motorObjectLevel;

    private void Awake()
    {
        headObjectLevel = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevel= GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevel= GameObject.Find("Motor").GetComponent<ObjectLevel>();
    }

    


    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("MiniBomb"))
         {
             Destroy(other.gameObject);
         }

        if ( other.CompareTag("Bomb") )
        {
            
            


                if (headObjectLevel.damageLevel <7)
                {
                    headObjectLevel.damageLevel += 1;
                    headObjectLevel.SetFalse2();
                    headObjectLevel.SetTrue2();
                }
                if ( bodyObjectLevel.damageLevel <7)
                {
                    bodyObjectLevel.damageLevel += 1;
                    bodyObjectLevel.SetFalse2();
                    bodyObjectLevel.SetTrue2();
                }
                if ( motorObjectLevel.damageLevel <7)
                {
                    motorObjectLevel.damageLevel += 1;
                    motorObjectLevel.SetFalse2();
                    motorObjectLevel.SetTrue2();
                }
                StartCoroutine(CloseLensAnim());
                
               
            
                
            
            
            
        }

       
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}

