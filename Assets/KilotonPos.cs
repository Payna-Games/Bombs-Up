using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KilotonPos : MonoBehaviour
{
    [SerializeField] private GameObject kilotonText;
    private RectTransform kilotonTextRectTransform;

    private void Start()
    {
        kilotonTextRectTransform = kilotonText.GetComponent<RectTransform>();
    }

    public IEnumerator TextRotater()
    {
        yield return new WaitForSeconds(3f);
        kilotonTextRectTransform.localPosition = Vector3.zero;
         kilotonTextRectTransform.localRotation =  Quaternion.Euler(-7.93f, 0f, 0f);
          kilotonTextRectTransform.localPosition = new Vector3(-0.51f, -5.37f, 0f);

    }

    public void TextPosition()
    {
        StartCoroutine(TextRotater());
        
    }
}
