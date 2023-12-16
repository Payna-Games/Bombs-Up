using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForDescent : MonoBehaviour
{
    public List<GameObject> ActiveObj;

    private void Awake()
    {
        YsoCorp.GameUtils.YCManager.instance.OnGameStarted(PlayerPrefs.GetInt("LevelCount"));

    }
    public void MakeFalseActive()
    {
        foreach (GameObject item in ActiveObj)
        {
            item.SetActive(false);
        }
    }
}
