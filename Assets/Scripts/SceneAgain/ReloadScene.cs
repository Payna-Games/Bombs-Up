using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeSceneIndex);
    }
}
