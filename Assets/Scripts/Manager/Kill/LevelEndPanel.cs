using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelEndPanel : MonoBehaviour
{
    private Kill killScript;
    [SerializeField] private StarCount starCount;
    public List<GameObject> objList;
    [SerializeField] private Transform[] panelObjects;
    

    void Awake()
    {
        killScript = transform.GetComponent<Kill>();
        killScript.killCount += NextLevel;
    }

    public void NextLevel(float obj)
    {
        // if (obj >= 0.01f)
        // {
        //     StartCoroutine(Wait(objList[0]));
        // }
        // else
        // {
        //     StartCoroutine(Wait(objList[1]));
        // }
        StartCoroutine(Wait(objList[0]));
    }
    IEnumerator Wait(GameObject activePanel)
    {
        yield return new WaitForSeconds(5);
        activePanel.SetActive(true);
        ParticleSystem confet = Instantiate(GameAssets.i.effects[1], panelObjects[0].position, Quaternion.identity);
        confet.Play();
        
        panelObjects[1].GetComponent<CanvasGroup>().DOFade(1f ,1f).From(0.2f);
        panelObjects[2].transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.7f).SetEase(Ease.OutBounce);
            //OnComplete(() =>
        // {
        //
        //     panelObjects[2].transform.DOScale(new Vector3(1f, 1f, 1f), 0.7f);
        // });
        
        
        yield return new WaitForSeconds(0.5f);
        starCount.StarCountt();
        yield return new WaitForSeconds(1.5f);
        panelObjects[3].transform.GetComponent<CanvasGroup>().DOFade(1, 1).From(0);

    }
}
