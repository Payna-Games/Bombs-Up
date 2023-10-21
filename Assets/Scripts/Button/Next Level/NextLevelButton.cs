using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevel()
    {
        YsoCorp.GameUtils.YCManager.instance.OnGameFinished(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
