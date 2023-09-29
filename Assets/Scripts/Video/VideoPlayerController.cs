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
        videoPlayer.loopPointReached += EndReached;
        nextLevel = 1;
    }

    void EndReached(VideoPlayer vp)
    {
        // Sonraki sahneye ge�i� yap
        SceneManager.LoadScene(nextLevel); // S�radaki sahnenin ad�n� de�i�tirin
    }
}
