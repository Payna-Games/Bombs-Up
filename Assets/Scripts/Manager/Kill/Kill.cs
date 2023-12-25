using System;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using System.Collections;
using DG.Tweening;

public class Kill : MonoBehaviour
{
    [SerializeField] private GameObject barImage;
    [SerializeField] private Image barFilledImage;
    [SerializeField] private Image explodeBar;
    
    public static Kill kill;
    
    public Transform bomp;
    public int maxObj;
    public float fillAmount;
    public float fillAmount2;
    public EnoughMoney IncomeScript;
    public float moneyIncrease;
    public event Action<float> killCount;
    public float destroyedObject;
    private Vector3 explodeBarScale;
    private float fill;

    private bool fillControl;
    private float tolerance = 0.05f;

    void Awake()
    {
        bomp.GetComponent<BompExplode>().explodeCount += KillCount;
        bomp.GetComponent<BompExplode>().explodeCount += BarCount;
       
        kill = kill == null ? this : kill;
        explodeBarScale = explodeBar.rectTransform.localScale;
        explodeBar.rectTransform.localScale = new Vector3(0, 0, 0);

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
            if (explodeBar != null)
            {
                explodeBar.gameObject.SetActive(true);
                explodeBar.rectTransform.DOScale(explodeBarScale, 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    fill = Mathf.Lerp(0, fillAmount2, Time.deltaTime * 1f);
                    barFilledImage.fillAmount += fill;
                    if (barFilledImage.fillAmount >= (1 - tolerance) * fillAmount2)
                    {

                        fillControl = false;
                        StartCoroutine(CloseBar());


                    }
                });

            }
           
        }
        

     
        
    }

    private IEnumerator CloseBar()
    {
        
        
            
        
        yield return new WaitForSeconds(2f);
        explodeBar.rectTransform.DOScale(Vector3.zero, 0.4f)
            .SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.2f);

        barImage.SetActive(false);


    }
}
