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
    [SerializeField] private GameObject extraBomb;
    [SerializeField] private Transform[] extraBombPositions;
    
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
            Destroy(other.gameObject);
           
        }

        if (other.CompareTag("Bomb"))
        {
            Instantiate(extraBomb, extraBombPositions[0].position, Quaternion.identity);
            Debug.Log("instantiate");
        }
    }
}