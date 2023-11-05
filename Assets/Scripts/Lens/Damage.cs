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

    private void Start()
    {
        headObjectLevel = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevel = GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevel = GameObject.Find("Motor").GetComponent<ObjectLevel>();
    }


    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("MiniBomb"))
         {
             Destroy(other.gameObject);
         }

        if ( other.CompareTag("Bomb") )
        {
            
                StartCoroutine(CloseLensAnim());


                if (headObjectLevel.damageLevel <8)
                {
                    headObjectLevel.damageLevel += 1;
                    headObjectLevel.SetFalse2();
                    headObjectLevel.SetTrue2();
                }
                if ( bodyObjectLevel.damageLevel <8)
                {
                    bodyObjectLevel.damageLevel += 1;
                    bodyObjectLevel.SetFalse2();
                    bodyObjectLevel.SetTrue2();
                }
                if ( motorObjectLevel.damageLevel <8)
                {
                    motorObjectLevel.damageLevel += 1;
                    motorObjectLevel.SetFalse2();
                    motorObjectLevel.SetTrue2();
                }
                
                
               
            
                other.transform.localScale *= 1.4f; 
            
            
            //Debug.Log("a");
        }

       
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}

