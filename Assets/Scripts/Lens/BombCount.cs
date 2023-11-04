using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BombCount : MonoBehaviour
{
    [SerializeField] private int bombCount;
    [SerializeField] private TextMeshProUGUI bombCountText;
    
    // private int addBombCount;

    private void Start()
    {
        bombCountText.text = bombCount.ToString();
    }

    public int AddBombCount()
    {
        
        return bombCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            bombCount++;
            bombCountText.text = bombCount.ToString();
        }
    }
}