using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class IsNextLevel : MonoBehaviour
{
    private Kill killScript;
    public List<GameObject> saveDataObj;
    // Start is called before the first frame update
    void Awake()
    {
        killScript = transform.GetComponent<Kill>();
        killScript.killCount += NextLevel;
    }

    private void NextLevel(float obj)
    {
        if (obj >= 0.01f)
        { 
            StartCoroutine(StartSmokeCoroutine());
        }
    }
    private IEnumerator StartSmokeCoroutine()
    {
        yield return new WaitForSeconds(5f);
        NextSceneData();
    }
    private void NextSceneData()
    {
        int incomeButton = saveDataObj[0].GetComponent<EnoughMoney>().clickCount;
        int addButton = saveDataObj[1].GetComponent<EnoughMoney>().clickCount;
        float totalMoney = saveDataObj[2].GetComponent<MoneyManager>().totalMoney;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(saveDataObj[0].name, incomeButton);
        PlayerPrefs.SetInt(saveDataObj[1].name, addButton);
        PlayerPrefs.SetFloat(saveDataObj[2].name, totalMoney);
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
    }
}
