using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TutorialMerge : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform mainBomb;
    public List<GameObject> masks;
    public float moveDuration = 1.0f;
    public Transform part1;
    public Transform part2;
    
    private bool conditionMet;
    public bool mergePart;
    public bool mergeBomp;
    [SerializeField] private RectTransform p1;
    [SerializeField] private RectTransform p2;
    [SerializeField] private RectTransform bombRectTransform;
    void Start()
    {
        conditionMet = true;
        mergePart = true;
        mergeBomp = false;
        part1.GetComponent<DragAndDrop>().tutorialMerge += LoopAnimEnd;
        part2.GetComponent<DragAndDrop>().tutorialMerge += LoopAnimEnd;
        
        //if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        //{
          
        //}
        //else if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        //{
        //    part1Pos = new Vector3(0, 350, 0);
        //    part2Pos = new Vector3(-200, 350, 0);
        //}
        //else
        //{
        //    part1Pos = new Vector3(0, 350, 0);
        //    part2Pos = new Vector3(-200, 350, 0);
        //}

       
    }

    // Update is called once per frame
    void Update()
    {
        if (part2.gameObject.activeSelf && conditionMet && mergePart)
        {
            masks[0].SetActive(true);
            //Debug.Log("p1.position: " + p1.anchoredPosition);
            //Debug.Log("p2.position: " + p2.anchoredPosition);
          Debug.Log("gerçekleşti1");
            conditionMet = false;
            rectTransform.DOAnchorPos(p1.anchoredPosition, moveDuration)
               
                .OnComplete(() => rectTransform.DOAnchorPos(p2.anchoredPosition, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        else if (part1.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
            Debug.Log("gerçekleşti2");
            masks[0].SetActive(false);
            conditionMet = false;
            rectTransform.DOAnchorPos(bombRectTransform.anchoredPosition, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(p2.anchoredPosition, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        else if (part2.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
            Debug.Log("gerçekleşti3");
            masks[0].SetActive(false);
            conditionMet = false;
            rectTransform.DOAnchorPos(bombRectTransform.anchoredPosition, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(p2.anchoredPosition, moveDuration)
                .OnComplete(() => conditionMet = true));
        }

        if (mainBomb.GetChild(1).GetComponent<ObjectLevel>().objectLevel >= 1)
        {
            masks[0].SetActive(false);
        }

    }
    private void LoopAnimEnd()
    {
        mergePart = false;
        mergeBomp = true;
    }
    private void LoopAnimBomp()
    {
        mergeBomp = false;
    }
}
