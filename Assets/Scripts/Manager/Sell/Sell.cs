using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    public Button addButton;

    public void OnPointExit()
    {
        ObjectList.objectList.DragObject.GetComponent<ObjectLevel>().objectLevel = 0;
        ObjectList.objectList.DragObject.GetComponent<DragAndDrop>().PrevGridNull();
        ObjectList.objectList.DragObject.SetActive(false);       
    }

    public void SellObject()
    {
        SlotAddButton.slotAddButton.ButtonActive();
        float money = (float)addButton.GetComponent<EnoughMoney>().enough;
        MoneyManager.moneyManager.InreaseTotalMoney(money-(money/10));        
    }
}
