using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialGoButton : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    bool isAnimLoop;

    Vector3 pos1;
    Vector3 pos2;

    float moveDuration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        isAnimLoop = false;
        part1.GetComponent<DragAndDrop>().tutorialBompMerge += TutorialGoButton_tutorialBompMerge;
        part2.GetComponent<DragAndDrop>().tutorialBompMerge += TutorialGoButton_tutorialBompMerge;
        pos1 = new Vector3(-0.3f, 6, -5);
        pos2 = new Vector3(-0.3f, 6, -6);
    }

    private void TutorialGoButton_tutorialBompMerge()
    {
        isAnimLoop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimLoop)
        {
            isAnimLoop = false;
            transform.DOMove(pos1, moveDuration)
                .OnComplete(() => transform.DOMove(pos2, moveDuration)
                .OnComplete(() => isAnimLoop = true));
        }
    }

    public void HandActiveFasle()
    {
        transform.gameObject.SetActive(false);
    }
}
