using System;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using YsoCorp.GameUtils;
public class Kill : MonoBehaviour
{
    [SerializeField] private GameObject barImage;
    [SerializeField] private Image barFilledImage;
    [SerializeField] private Image explodeBar;
    [SerializeField] private Image[] citysBarImage;

    public static Kill kill;
    
    public Transform bomp;
    public int maxObj;
    public float fillAmount;
    private float fillAmount2;
    public EnoughMoney IncomeScript;
    public float moneyIncrease;
    public event Action<float> killCount;
    public float destroyedObject;
    private Vector3 explodeBarScale;
    private float fill;

    private bool fillControl;
    private bool setActiveControl;

    private float tolerance = 0.05f;

    void Awake()
    {
        kill = kill == null ? this : kill;

        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            bomp.GetComponent<BompExplode>().explodeCount += KillCount;
            
            
           
            
        }
        if(YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            bomp.GetComponent<BompExplode>().explodeCount += KillCount;
            

            bomp.GetComponent<BompExplode>().explodeCount += BarCount;
            explodeBarScale = explodeBar.rectTransform.localScale;
            explodeBar.rectTransform.localScale = new Vector3(0, 0, 0);
        }
           

    }

    private void KillCount(int objCount)
    {
        destroyedObject = objCount;
        fillAmount = ((float)objCount / maxObj);

        
      killCount?.Invoke(fillAmount);
        MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * fillAmount); // 6.25 olan sabit 5 idi çeyreği kadar fazlalaştırıldı
    }

    private void BarCount(int objCount)
    {
        destroyedObject = objCount;
        fillAmount2 = ((float) KiloTonCalculate.kiloTonCalculate.KiloTon / Kill.kill.maxObj );
        Debug.Log("fillAmount2 " + fillAmount2);
        setActiveControl = true;
        fillControl = true;
     
    }
   
    private void Update()

    {
        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
           // Debug.Log("oldVersion");
        }
        else
        {
            if (setActiveControl)
            {
                explodeBar.gameObject.SetActive(true);
                if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 5)
                {
                    citysBarImage[0].gameObject.SetActive(true);
                    citysBarImage[1].gameObject.SetActive(false);
                }
                else if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 5)
                {
                    citysBarImage[1].gameObject.SetActive(true);
                    citysBarImage[0].gameObject.SetActive(false);
                    citysBarImage[3].gameObject.SetActive(true);
                    citysBarImage[2].gameObject.SetActive(false);
                }
                setActiveControl = false;
            }

            if (fillControl)
            {
                if (explodeBar != null)
                {

                    explodeBar.rectTransform.DOScale(explodeBarScale, 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        //fill = Mathf.Lerp(0, fillAmount2, Time.deltaTime * 1f);
                        // barFilledImage.fillAmount = Mathf.Lerp(0, fillAmount2, Time.deltaTime * 1f);
                        Fill();
                        if (barFilledImage.fillAmount >= (1 - tolerance) * fillAmount2 && barFilledImage.fillAmount <= (1 + tolerance) * fillAmount2)
                        {

                            fillControl = false;
                            StartCoroutine(CloseBar());


                        }
                    });

                }

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
    private void Fill()
    {
        barFilledImage.fillAmount += 0.35f * Time.deltaTime; 
    }
}
