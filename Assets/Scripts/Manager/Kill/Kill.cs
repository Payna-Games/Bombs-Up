using System;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using System.Collections;

public class Kill : MonoBehaviour
{
    public static Kill kill;
    public Transform bomp;
    public int maxObj;
    public float fillAmount;
    public float fillAmount2;
    public EnoughMoney IncomeScript;
    public float moneyIncrease;
    public event Action<float> killCount;
    public float destroyedObject;
    //[SerializeField] private MaxKiloton kiloton;
    [SerializeField] private GameObject barImage;
    float currentVelocity = 0f;

    void Awake()
    {
        bomp.GetComponent<BompExplode>().explodeCount += KillCount;
        bomp.GetComponent<BompExplode>().explodeCount += BarCount;
        kill = kill == null ? this : kill;
    }

    private void KillCount(int objCount)
    {
        destroyedObject = objCount;
        fillAmount = ((float)objCount / maxObj);

        transform.GetComponent<Image>().fillAmount = Mathf.Lerp(0, fillAmount,1);
        //Debug.Log("bar y�zdesi " + transform.GetComponent<Image>().fillAmount + " " + objCount + " " + maxObj);

        killCount?.Invoke(fillAmount);
        MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * fillAmount); // 6.25 olan sabit 5 idi çeyreği kadar fazlalaştırıldı
    }

    private void BarCount(int objCount)
    {
        fillAmount2 = ((float)objCount / maxObj );
        Transform barFilledTransform = barImage.transform.GetChild(0);
        GameObject barFilledImage = barFilledTransform.gameObject;

        LeanTween.scaleX(barFilledImage, fillAmount2,1.5f);
        StartCoroutine(CloseBar());


    }
    private  IEnumerator CloseBar()
    {
        yield return new WaitForSeconds(3f);
        barImage.SetActive(false);
    }
  

}
