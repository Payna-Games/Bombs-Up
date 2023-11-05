using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Damage : MonoBehaviour
{
    [SerializeField] private int addDamage;
    [SerializeField] private TextMeshProUGUI damageText;

     
    
    

    private void Start()
    {
        damageText.text = addDamage.ToString();
        addDamage = 0;
    }

    

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("MiniBomb"))
         {
            // addDamage++;
            
             //damageText.text = addDamage.ToString();
             Destroy(other.gameObject);
         }

        if ( other.CompareTag("Bomb") )
        {
            
                StartCoroutine(CloseLensAnim());
                ObjectLevel headObjectLevel = GameObject.Find("Head").GetComponent<ObjectLevel>();
                ObjectLevel bodyObjectLevel = GameObject.Find("Body").GetComponent<ObjectLevel>();
                ObjectLevel motorObjectLevel = GameObject.Find("Motor").GetComponent<ObjectLevel>();

                headObjectLevel.damageLevel += 2;
                headObjectLevel.SetFalse2();
                headObjectLevel.SetTrue2();
                bodyObjectLevel.damageLevel += 2;
                bodyObjectLevel.SetFalse2();
                bodyObjectLevel.SetTrue2();
                motorObjectLevel.damageLevel += 2;
                motorObjectLevel.SetFalse2();
                motorObjectLevel.SetTrue2();
            
                other.transform.localScale *= 1.2f; 
            
            
            //Debug.Log("a");
        }

       
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}

