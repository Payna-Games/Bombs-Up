using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SellImage : MonoBehaviour
{
    Vector3 originalScale;
    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {Sell.sell.mouseUp = true;
        transform.DOScale(originalScale * 0.85f, 1.0f);
        
    }
    private void OnTriggerExit(Collider other)
    {Sell.sell.mouseUp = false;
        transform.DOScale(originalScale, 1.0f);
        
    }
}
