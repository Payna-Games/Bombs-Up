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
        fireRangeText.text = addFireRange.ToString();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRange++;
           
            fireRangeText.text = addFireRange.ToString();
            
        }

        if (other.CompareTag("Bomb"))
        {
            MiniBompManager.miniBompManager.range += addFireRange*10;
        }
    }
}


