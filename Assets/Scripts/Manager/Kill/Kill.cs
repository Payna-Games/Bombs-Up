using System;
using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    public Transform bomp;
    public int maxObj;

    public EnoughMoney IncomeScript;
    public event Action<float> killCount; 

    void Awake()
    {
        bomp.GetComponent<BompExplode>().explodeCount += KillCount;
    }

    private void KillCount(int objCount)
    {
        float fillAmount = ((float)objCount / maxObj);

        transform.GetComponent<Image>().fillAmount = Mathf.Lerp(0, fillAmount,1);
        Debug.Log("bar yüzdesi " + transform.GetComponent<Image>().fillAmount + " " + objCount + " " + maxObj);

        killCount?.Invoke(fillAmount);
        MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 5 * fillAmount);
    }

}
