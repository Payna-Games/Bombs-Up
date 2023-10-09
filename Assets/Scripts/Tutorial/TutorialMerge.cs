using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialMerge : MonoBehaviour
{
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
        bompBody = new Vector3(0, 15, 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (part2.gameObject.activeSelf && conditionMet && mergePart)
        {
            part1Pos = new Vector3(part1.position.x - 0.7f, part1.position.y + 6f, part1.position.z + -1.5f);
            part2Pos = new Vector3(part2.position.x - 0.7f, part2.position.y + 6f, part2.position.z + -1.5f);
            transform.position = part1Pos;
            conditionMet = false;
            transform.DOMove(part2Pos, moveDuration)
                .OnComplete(() => transform.DOMove(part1Pos, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        if (part1.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
            transform.position = part1Pos;
            conditionMet = false;
            transform.DOMove(bompBody, moveDuration)
                .OnComplete(() => transform.DOMove(part1Pos, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        if (part2.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
            transform.position = part2Pos;
            conditionMet = false;
            transform.DOMove(bompBody, moveDuration)
                .OnComplete(() => transform.DOMove(part2Pos, moveDuration)
                .OnComplete(() => conditionMet = true));
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
