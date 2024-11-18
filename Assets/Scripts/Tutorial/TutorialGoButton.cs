using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialGoButton : MonoBehaviour
{
    public RectTransform handRect;
    public GameObject masks;
    public GameObject part1;
    public GameObject part2;
    bool isAnimLoop;
    [SerializeField] private RectTransform goPos1;
    [SerializeField] private RectTransform goPos2;

   
    bool isEnd;
    bool one;

    float moveDuration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        one = true;
        isEnd = false;
        isAnimLoop = false;
        part1.GetComponent<DragAndDrop>().tutorialBompMerge += TutorialGoButton_tutorialBompMerge;
        part2.GetComponent<DragAndDrop>().tutorialBompMerge += TutorialGoButton_tutorialBompMerge;
      

    }

    private void TutorialGoButton_tutorialBompMerge(int level)
    {
        if (one && level ==1)
        {
            isAnimLoop = true;
            masks.gameObject.SetActive(true);
            one = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimLoop)
        {
            isAnimLoop = false;
            ClickCount.clickCount.GetComponent<Button>().interactable = true;
            handRect.DOAnchorPos(goPos1.anchoredPosition, moveDuration)
                .OnComplete(() => handRect.DOAnchorPos(goPos2.anchoredPosition, moveDuration)
                .OnComplete(() => isAnimLoop = true));
        }
        if (ClickCount.clickCount.goClickCount >0)
        {
            masks.gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
            isEnd = false;
        }
    }

    public void HandActiveFasle()
    {
        isEnd = true;
    }
}