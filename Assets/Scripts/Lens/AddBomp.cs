using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBomp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            for (int i = 0; i < other.transform.GetChild(8).childCount; i++)
            {
                if (!other.transform.GetChild(8).GetChild(i).gameObject.activeSelf)
                {
                    other.transform.GetChild(8).GetChild(i).gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void SetTrue()
    {

    }
}
