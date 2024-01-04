using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using YsoCorp.GameUtils;

public class LevelEndPanel : MonoBehaviour
{
    private Kill killScript;
    [SerializeField] private StarCount starCount;
    public List<GameObject> objList;
    [SerializeField] private Transform[] panelObjects;
    [SerializeField] private Transform multiplier;
    private Vector3 multiplierFirstScale;
    [SerializeField] private RectTransform moneyButtonTrans;
    private Vector3 moneyButtonScale;

    void Awake()
    {
        killScript = transform.GetComponent<Kill>();
        killScript.killCount += NextLevel;
        multiplierFirstScale = multiplier.localScale;
        moneyButtonScale = moneyButtonTrans.localScale;

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
         
        
        if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            yield return new WaitForSeconds(0.7f);
        }
        else
        {
            yield return new WaitForSeconds(5f);
        }



        activePanel.SetActive(true);
        ParticleSystem confet = Instantiate(GameAssets.i.effects[1], panelObjects[0].position, Quaternion.identity);
        confet.Play();
        multiplier.transform.localScale = new Vector3(0, 0, 0);
        multiplier.transform.DOScale((multiplierFirstScale), 0.3f).SetEase(Ease.OutBounce);
        moneyButtonTrans.DOLocalMove(new Vector3(0, -256f, 0.18f), 1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {

            StartCoroutine(MoneyBtScaleAnim());
         });



        panelObjects[1].GetComponent<CanvasGroup>().DOFade(1f ,1f).From(0.2f);
        panelObjects[2].transform.DOScale(new Vector3(0.6f, 0.8f, 0.6f), 0.7f).SetEase(Ease.OutBounce);
            //OnComplete(() =>
        // {
        //
        //     panelObjects[2].transform.DOScale(new Vector3(1f, 1f, 1f), 0.7f);
        // });
        
        
        yield return new WaitForSeconds(0.5f);
        starCount.StarCountt();
        yield return new WaitForSeconds(2f);
        panelObjects[3].transform.GetComponent<CanvasGroup>().DOFade(1, 1).From(0);
        NextLevelButton.nextLevelButton.clicked = false;

    }
    IEnumerator MoneyBtScaleAnim()
    {
        while (true)
        {

            moneyButtonTrans.DOScale(new Vector3(2.2f, 5.2f, 2.2f), 0.4f).SetEase(Ease.Linear);

            yield return new WaitForSeconds(0.6f);
            moneyButtonTrans.DOScale(moneyButtonScale, 0.4f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.6f);

        }
    }
}
