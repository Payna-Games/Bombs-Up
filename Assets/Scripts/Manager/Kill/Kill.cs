using System;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using System.Collections;

public class Kill : MonoBehaviour
{
    [SerializeField] private GameObject barImage;
    [SerializeField] private Image barFilledImage;
    public static Kill kill;
    
    public Transform bomp;
    public int maxObj;
    public float fillAmount;
    public float fillAmount2;
    public EnoughMoney IncomeScript;
    public float moneyIncrease;
    public event Action<float> killCount;
    public float destroyedObject;

    private float fill;

    private bool fillControl;
    private float tolerance = 0.05f;

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
        fillControl = true;







    }
   
    private void Update()
    {
        if (fillControl)
        {
            fill = Mathf.Lerp(0, fillAmount2, Time.deltaTime * 1f);
            barFilledImage.fillAmount += fill;
            if (barFilledImage.fillAmount >= (1 - tolerance) * fillAmount2)
            {

                fillControl = false;
                StartCoroutine(CloseBar());


            }
        }
        

     
        
    }

    private IEnumerator CloseBar()
    {
        yield return new WaitForSeconds(3f);
        if (barImage != null)
        {
            barImage.SetActive(false);

        }

    }
}
