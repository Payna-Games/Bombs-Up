using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class NextLevelButton : MonoBehaviour
{
    public static NextLevelButton nextLevelButton;
    [SerializeField] private Transform moneyParticlePosition;
    private RectTransform rectTransform;


    // [SerializeField]  private Transform moneyParticlePosition;
    private bool clicked;
    public EnoughMoney IncomeScript;
    private bool _ads = false;

    private void Awake()
    {
        nextLevelButton = nextLevelButton == null ? this : nextLevelButton;
    }

    private void Start()
    {
        clicked = false;
        //IncomeScript = GameObject.Find("Income").GetComponent<EnoughMoney>();
        rectTransform = GetComponent<RectTransform>();
    }

    private IEnumerator NextLevelParticle()
    {
        
        yield return new WaitForSeconds(1.5f);
        if (!PlayerPrefs.HasKey("LevelCount"))
            PlayerPrefs.SetInt("LevelCount", 1);
        else
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
        Debug.Log("courutine else");
        
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("Level-10");
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextLevel()
    {
       
        _ads = true;
        YsoCorp.GameUtils.YCManager.instance.OnGameFinished(_ads);

        if (!clicked)
        {
             
            rectTransform.DOScale(Vector3.one * 2.4f, 0.4f).SetEase(Ease.OutQuad)
                       .OnComplete(() =>
                       {
                           rectTransform.DOScale(Vector3.one * 3.3f, 0.4f)
                               .SetEase(Ease.OutBounce);
                       });

            YsoCorp.GameUtils.YCManager.instance.adsManager.ShowInterstitial
            (() => {
               
                MoneyManager.moneyManager.buttonClicked = true;

                MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount);

                StartCoroutine(NextLevelParticle());

              // transform.GetChild(0).gameObject.SetActive(false);
               
            });
            MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount); 

            ParticleSystem moneyParticle = Instantiate(GameAssets.i.effects[6], moneyParticlePosition.position, Quaternion.identity); ;
            moneyParticle.Play();
            clicked = true;
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
