using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSave : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            YsoCorp.GameUtils.YCManager.instance.OnGameStarted(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().buildIndex);
        }
    }
}
