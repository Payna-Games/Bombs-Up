using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPanel : MonoBehaviour
{
    private Kill killScript;
    public List<GameObject> objList;

    void Awake()
    {
        killScript = transform.GetComponent<Kill>();
        killScript.killCount += NextLevel;
    }

    public void NextLevel(float obj)
    {
        if (obj >= 0.8)
        {
            StartCoroutine(Wait(objList[0]));
        }
        else
        {
            StartCoroutine(Wait(objList[1]));
        }
    }
    IEnumerator Wait(GameObject activePanel)
    {
        yield return new WaitForSeconds(5);
        activePanel.SetActive(true);
    }
}
