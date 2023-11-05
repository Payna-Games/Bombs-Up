using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FireRate : MonoBehaviour
{
    [SerializeField] private int addFireRateText;
    [SerializeField] private TextMeshProUGUI fireRateText;
    
    

    private void Start()
    {
        fireRateText.text = addFireRateText.ToString();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            addFireRateText++;
           
            fireRateText.text = addFireRateText.ToString();
            
        }

        if (other.CompareTag("Bomb"))
        {
            if (addFireRateText != 0)
            {
                MiniBompManager.miniBompManager.speed += addFireRateText;
            }
            
        }
    }
}
