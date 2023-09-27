using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    public Button addButton;

    public void OnPointExit()
    {
        ObjectList.objectList.DragObject.GetComponent<ObjectLevel>().objectLevel = 0;
        ObjectList.objectList.DragObject.SetActive(false);
        ObjectList.objectList.DragObject.GetComponent<DragAndDrop>().PrevGridNull();
    }

    public void SellObject()
    {
        float money = (float)addButton.GetComponent<EnoughMoney>().enough;
        MoneyManager.moneyManager.InreaseTotalMoney(money);
    }
}
