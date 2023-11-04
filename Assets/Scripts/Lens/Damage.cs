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
            addDamage++;
           
            damageText.text = addDamage.ToString();
            
        }

        if (other.CompareTag("B_Head") || other.CompareTag("B_Engine") ||other.CompareTag("B_Body") )
        {
            
            ObjectLevel objectlevel =other.GetComponent<ObjectLevel>();
            objectlevel.damageLevel = objectlevel.objectLevel;
            objectlevel.damageLevel += addDamage;
            objectlevel.SetFalse2();
            objectlevel.SetTrue2();
            other.transform.localScale *= 1.2f;

        }
    }
}

