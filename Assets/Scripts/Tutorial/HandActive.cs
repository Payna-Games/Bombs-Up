using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandActive : MonoBehaviour
{
    public Transform bomp;
    public GameObject masks;
    void Update()
    {
        if (SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount >=3 && bomp.GetChild(1).GetComponent<ObjectLevel>().objectLevel > 0 && ClickCount.clickCount.goClickCount >= 1)
        {
            masks.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
