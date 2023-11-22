using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUi : MonoBehaviour
{
    private bool hasWon;
    void Start()
    {
        hasWon = false;
        if (SceneManager.GetActiveScene().name.Contains("Tutorial"))
        {
            GetComponent<TextMeshProUGUI>().text = "Tutorial";
            //if (!PlayerPrefs.HasKey(transform.name))
            //{
            //    PlayerPrefs.SetInt(transform.name, SceneManager.GetActiveScene().buildIndex);
            //}
            //else
            //    SceneManager.LoadScene(PlayerPrefs.GetInt(transform.name));
            OnGameStarted(1);
        }

        else
        {
            GetComponent<TextMeshProUGUI>().text = "Lvl " + (PlayerPrefs.GetInt("LevelCount"));
            PlayerPrefs.SetInt(transform.parent.name, SceneManager.GetActiveScene().buildIndex);
            OnGameStarted(PlayerPrefs.GetInt("LevelCount") + 1 );
        }

      
        
    }


    private void OnGameStarted(int levelNumber)
    {
        YsoCorp.GameUtils.YCManager.instance.OnGameStarted(levelNumber);
    }

    
}
