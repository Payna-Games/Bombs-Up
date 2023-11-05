using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageDown : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI damageText;
    private ObjectLevel headObjectLevell;
    private ObjectLevel bodyObjectLevell;
    private ObjectLevel motorObjectLevell;
    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float targetScale = 1.5f;
    [SerializeField] private float duration = 1f;
    

    private void Awake()
    {
        headObjectLevell = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevell= GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevell= GameObject.Find("Motor").GetComponent<ObjectLevel>();
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            
            Destroy(other.gameObject);
        }

        if ( other.CompareTag("Bomb") )
        {
            
          

            if (headObjectLevell.damageLevel >0)
            {
                headObjectLevell.damageLevel -= 1;
                headObjectLevell.SetFalse2();
                headObjectLevell.SetTrue2();
            }
            if (bodyObjectLevell.damageLevel >0)
            {
                bodyObjectLevell.damageLevel -= 1;
                bodyObjectLevell.SetFalse2();
                bodyObjectLevell.SetTrue2();
            }
            if ( motorObjectLevell.damageLevel >0)
            {
                motorObjectLevell.damageLevel -= 1;
                motorObjectLevell.SetFalse2();
                motorObjectLevell.SetTrue2();
            }
            StartCoroutine(CloseLensAnim());


            other.transform.DOScale(Vector3.one * targetScale, 0.5f)
                .SetEase(Ease.Linear) 
                .OnComplete(() =>
                {

                    other.transform.DOScale(Vector3.one * initialScale, duration)
                        .SetEase(Ease.OutBounce);

                });
            
               
                
            
            


        }

       
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}


