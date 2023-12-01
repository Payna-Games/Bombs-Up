using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField]  private Transform moneyParticlePosition;
    private bool clicked;
    public EnoughMoney IncomeScript;
    
    private void Start()
    {
        clicked = false;
        //IncomeScript = GameObject.Find("Income").GetComponent<EnoughMoney>();
        
    }

    private IEnumerator NextLevelParticle()
    {
        
        yield return new WaitForSeconds(1.5f);
        if (!PlayerPrefs.HasKey("LevelCount"))
            PlayerPrefs.SetInt("LevelCount", 1);
        else
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);

        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            
            SceneManager.LoadScene("Level-011");
            


        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextLevel()
    {
       
        if (!clicked)
        {
            MoneyManager.moneyManager.buttonClicked = true;
            MoneyManager.moneyManager.InreaseTotalMoney(IncomeScript.clickCount * 300 * 17f * Kill.kill.fillAmount); // 6.25 olan sabit 5 idi �eyre�i kadar fazlala�t�r�ld�
            ParticleSystem moneyParticle = Instantiate(GameAssets.i.effects[6], moneyParticlePosition.position, Quaternion.identity);
            moneyParticle.Play();

            StartCoroutine(NextLevelParticle());

            transform.GetChild(0).gameObject.SetActive(false);
            clicked = true;
        }
        
        
    }
}
