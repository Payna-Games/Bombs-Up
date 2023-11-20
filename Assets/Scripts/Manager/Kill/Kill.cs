using System;
using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    public static Kill kill;
    public Transform bomp;
    public int maxObj;
    public float fillAmount;
    public EnoughMoney IncomeScript;
    public event Action<float> killCount; 

    void Awake()
    {
        bomp.GetComponent<BompExplode>().explodeCount += KillCount;
        kill = kill == null ? kill : this;
    }

    private void KillCount(int objCount)
    {
        fillAmount = ((float)objCount / maxObj);

        transform.GetComponent<Image>().fillAmount = Mathf.Lerp(0, fillAmount,1);
        //Debug.Log("bar y�zdesi " + transform.GetComponent<Image>().fillAmount + " " + objCount + " " + maxObj);

        killCount?.Invoke(fillAmount);
        //MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * fillAmount); // 6.25 olan sabit 5 idi çeyreği kadar fazlalaştırıldı
    }

}
