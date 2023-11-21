using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandActive : MonoBehaviour
{
    public Transform bomp;
    public GameObject masks;
    public GameObject incomeButton;
    void Update()
    {
        if (SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount >=3 && bomp.GetChild(1).GetComponent<ObjectLevel>().objectLevel > 0 && ClickCount.clickCount.goClickCount >= 1)
        {
            ClickCount.clickCount.GetComponent<Button>().interactable = true;
            incomeButton.GetComponent<EnoughMoney>().CanInteract = true;
            masks.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
