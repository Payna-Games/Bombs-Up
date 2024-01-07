using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using YsoCorp.GameUtils;

public class NextLevelButton : MonoBehaviour
{
    public static NextLevelButton nextLevelButton;
    
    [SerializeField] private Transform moneyParticlePosition;
    private RectTransform rectTransform;
    


    // [SerializeField]  private Transform moneyParticlePosition;
    public bool clicked;
    public EnoughMoney IncomeScript;
    private bool _ads = false;

    private void Awake()
    {
        nextLevelButton = nextLevelButton == null ? this : nextLevelButton;
    }

    private void Start()
    {
        clicked = true ;
        //IncomeScript = GameObject.Find("Income").GetComponent<EnoughMoney>();
        rectTransform = GetComponent<RectTransform>();
        
    }

    private IEnumerator NextLevelParticle()
    {
        if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            yield return new WaitForSeconds(1.5f);
            if (!PlayerPrefs.HasKey("LevelCount"))
                PlayerPrefs.SetInt("LevelCount", 1);
            else
                PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
            Debug.Log("courutine else");

            if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(11);
            }
            if (KiloTonCalculate.kiloTonCalculate.KiloTon < Kill.kill.maxObj)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (KiloTonCalculate.kiloTonCalculate.KiloTon >= Kill.kill.maxObj)
            {
                SceneManager.LoadScene(11);
            }
        }
        else if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            yield return new WaitForSeconds(1.5f);
            if (!PlayerPrefs.HasKey("LevelCount"))
                PlayerPrefs.SetInt("LevelCount", 1);
            else
                PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
            Debug.Log("courutine else");

            if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(9);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else
        {
            yield return new WaitForSeconds(1.5f);
            if (!PlayerPrefs.HasKey("LevelCount"))
                PlayerPrefs.SetInt("LevelCount", 1);
            else
                PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
            Debug.Log("courutine else");

            if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(9);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

        //if(Kill.kill.destroyedObject != Kill.kill.maxObj)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        //}

    }

    public void NextLevel()
    {

        _ads = true;
        YsoCorp.GameUtils.YCManager.instance.OnGameFinished(_ads);

        if (!clicked)
        {
            Vector3 firstscale = transform.localScale;
            rectTransform.DOScale(new Vector3(1.1f, 3.8f, 1), 0.4f).SetEase(Ease.OutQuad)
                       .OnComplete(() =>
                       {
                           rectTransform.DOScale(firstscale, 0.4f)
                               .SetEase(Ease.OutBounce);
                       });

            YsoCorp.GameUtils.YCManager.instance.adsManager.ShowInterstitial
            (() => {

                if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
                {
                    MoneyManager.moneyManager.buttonClicked = true;

                    if (SceneManager.GetActiveScene().buildIndex <= SceneManager.sceneCountInBuildSettings - 5)
                    {
                        MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);
                    }
                    else if (SceneManager.GetActiveScene().buildIndex > SceneManager.sceneCountInBuildSettings - 5)
                    {
                        MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount * 1.8f);

                    }

                   
                }
                else if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
                {
                    MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);
                }
                else
                {
                    MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);
                }
                    StartCoroutine(NextLevelParticle());


                // transform.GetChild(0).gameObject.SetActive(false);

            });
            if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
            {
                if (SceneManager.GetActiveScene().buildIndex <= SceneManager.sceneCountInBuildSettings - 5)
                {
                    MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);
                }
                else if (SceneManager.GetActiveScene().buildIndex > SceneManager.sceneCountInBuildSettings - 5)
                {
                    MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount * 1.8f);

                }
            }
            else if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
            {
                MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);
            }
            else
            {
                MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);
            }


            ParticleSystem moneyParticle = Instantiate(GameAssets.i.effects[6], moneyParticlePosition.position, Quaternion.identity); ;
            
            //clicked = true;
        }


    }
    public void NextLevelReward()
    {
        _ads = true;
        YsoCorp.GameUtils.YCManager.instance.OnGameFinished(_ads);
        StartCoroutine(NextLevelParticle());
       
    }
    
    //public void MoneyParticle()
    //{
    //    ParticleSystem moneyParticle = Instantiate(GameAssets.i.effects[6], moneyParticlePosition.position, Quaternion.identity); ;
    //    moneyParticle.Play();
    //}

}
