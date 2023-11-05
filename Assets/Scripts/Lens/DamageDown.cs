using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class DamageDown : MonoBehaviour
{
    
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
            
           Debug.Log(headObjectLevel.objectLevel);
           Debug.Log(bodyObjectLevel.damageLevel);
           Debug.Log(motorObjectLevel.damageLevel);

            if (headObjectLevel.objectLevel >1)
            {
                headObjectLevel.damageLevel -= 1;
                headObjectLevel.SetFalse2();
                headObjectLevel.SetTrue2();
            }
            if (bodyObjectLevel.damageLevel >1)
            {
                bodyObjectLevel.damageLevel -= 1;
                bodyObjectLevel.SetFalse2();
                bodyObjectLevel.SetTrue2();
            }
            if ( motorObjectLevel.damageLevel >1)
            {
                motorObjectLevel.damageLevel -= 1;
                motorObjectLevel.SetFalse2();
                motorObjectLevel.SetTrue2();
            }
            StartCoroutine(CloseLensAnim());

            
            
            
           
            
            other.transform.localScale *= 0.6f; 
            
            
        }

       
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}


