using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using YG;


public class TutorialMerge : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform mainBomb;
    public List<GameObject> masks;
    public float moveDuration = 1.0f;
    public Transform part1;
    public Transform part2;
    [SerializeField] private RectTransform  bompBody;
    [SerializeField] private RectTransform part1Pos;
    [SerializeField] private RectTransform part2Pos;
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
        
       

        
    }

    // Update is called once per frame
    void Update()
    {
        if (part2.gameObject.activeSelf && conditionMet && mergePart)
        {
           // masks[0].SetActive(true);
            
        
            conditionMet = false;
            rectTransform.DOMove(part2Pos.position, moveDuration)
                .OnComplete(() => rectTransform.DOMove(part1Pos.position, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        else if (part1.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
          
           // masks[0].SetActive(false);
            conditionMet = false;
            rectTransform.DOMove(bompBody.position, moveDuration)
                .OnComplete(() => rectTransform.DOMove(part2Pos.position, moveDuration)
                .OnComplete(() => conditionMet = true));
        }
        else if (part2.GetComponent<ObjectLevel>().objectLevel == 1 && mergeBomp && conditionMet)
        {
          
          //  masks[0].SetActive(false);
            conditionMet = false;
            rectTransform.DOMove(bompBody.position, moveDuration)
                .OnComplete(() => rectTransform.DOMove(part1Pos.position, moveDuration)
                .OnComplete(() => conditionMet = true));
        }

        if (mainBomb.GetChild(1).GetComponent<ObjectLevel>().objectLevel >= 1)
        {
           // masks[0].SetActive(false);
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
