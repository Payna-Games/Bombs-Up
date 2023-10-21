using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        YsoCorp.GameUtils.YCManager.instance.OnGameFinished(false);

        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeSceneIndex);
    }
}
