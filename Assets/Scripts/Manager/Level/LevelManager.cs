using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey(transform.name))
        {
            PlayerPrefs.SetInt(transform.name, 1);
            PlayerPrefs.SetInt("levelNumber", 1);
            SceneManager.LoadScene(1);
        }
        else
            SceneManager.LoadScene(PlayerPrefs.GetInt(transform.name));
    }
}
