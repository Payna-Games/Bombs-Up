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
    private Vector3 bompBody;
    private Vector3 part1Pos;
    private Vector3 part2Pos;
    private bool conditionMet;
    public bool mergePart;
    public bool mergeBomp;
    void Start()
    {
        conditionMet = true;
        mergePart = true;
        mergeBomp = false;
        part1.GetComponent<DragAndDrop>().tutorialMerge += LoopAnimEnd;
        part2.GetComponent<DragAndDrop>().tutorialMerge += LoopAnimEnd;
        part1Pos = new Vector3(-92, 829, 0);
        part2Pos = new Vector3(-285, 829, 0);
        bompBody = new Vector3(-275, 1195, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (part2.gameObject.activeSelf && conditionMet && mergePart)
        {
            masks[0].SetActive(true);

            conditionMet = false;
            rectTransform.DOAnchorPos(part2Pos, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(part1Pos, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        else if (part1.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
            masks[0].SetActive(false);
            conditionMet = false;
            rectTransform.DOAnchorPos(bompBody, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(part1Pos, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        else if (part2.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
            masks[0].SetActive(false);
            conditionMet = false;
            rectTransform.DOAnchorPos(bompBody, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(part2Pos, moveDuration)
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
