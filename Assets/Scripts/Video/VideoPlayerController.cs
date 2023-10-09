using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int nextLevel;

    void Start()
    {
        videoPlayer.Play();
        nextLevel = 1;
        videoPlayer.loopPointReached += EndReached;
        if (PlayerPrefs.HasKey("level"))
        {
            nextLevel = PlayerPrefs.GetInt("level");
        }
        
    }

    void EndReached(VideoPlayer vp)
    {
        // Sonraki sahneye geçiþ yap
        SceneManager.LoadScene(nextLevel); // Sýradaki sahnenin adýný deðiþtirin
    }
}
