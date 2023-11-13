using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngineInternal;
using UnityEngine.UI;

public class KilotonPos : MonoBehaviour
{
    // private Image kilotonImage;
    private RectTransform kilotonTextRectTransform;

    private void Start()
    {
        //kilotonImage = GetComponent<Image>();
        kilotonTextRectTransform = GetComponent<RectTransform>();
       
    }

    public IEnumerator TextRotater()
    {
        yield return new WaitForSeconds(3f);

        kilotonTextRectTransform.anchoredPosition3D= new Vector3(-0.58f, -5f,0.27f); 
        kilotonTextRectTransform.localRotation=Quaternion.Euler(-15f,0,0);
        //  kilotonTextRectTransform.localPosition = new Vector3(-0.51f, -5.37f, 0f);

    }

    public void TextPosition()
    {
        StartCoroutine(TextRotater());
        
    }
}
