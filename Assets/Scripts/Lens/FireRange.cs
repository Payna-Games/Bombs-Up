using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRange : MonoBehaviour
{
    [SerializeField] private int addFireRange;
    [SerializeField] private TextMeshProUGUI fireRangeText;
    
    

    private void Start()
    {
        fireRangeText.text = "+" + addFireRange.ToString();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRange++;
           
            fireRangeText.text = "+" + addFireRange.ToString();
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Bomb"))
        {
            if(addFireRange !=0)
            {
                MiniBompManager.miniBompManager.range += addFireRange*10;
                StartCoroutine(CloseLensAnim());
            }
            
        }
    }
    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f); 
        gameObject.SetActive(false);
        
    }
}


