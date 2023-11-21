using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialGoButton : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject masks;
    public GameObject part1;
    public GameObject part2;
    bool isAnimLoop;

    Vector3 pos1;
    Vector3 pos2;
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
        pos1 = new Vector3(-280, -5, 0);
        pos2 = new Vector3(-280, -40, 0);

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
            rectTransform.DOAnchorPos(pos1, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(pos2, moveDuration)
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