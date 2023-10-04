using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonScale : MonoBehaviour
{
    private Button button;
    public float wait = 0.01f;
    private Vector3 targetSize;
    private Vector3 startSize;
    private Vector3 targetRot;
    private Vector3 startRot;

    private void Awake()
    {
        button = transform.GetComponent<Button>();
        startSize = button.transform.localScale;
        targetSize = button.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
        startRot = button.transform.eulerAngles;
        targetRot = button.transform.eulerAngles + new Vector3(0, 0, 5);
    }

    private RectTransform rectTransform;
    private void Start()
    {
        if (gameObject.name == "Sell Button")
        {
            rectTransform = GetComponent<RectTransform>();
            StartScaleAnimation();
        }
    }

    private void StartScaleAnimation()
    {

        targetSize = button.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(targetSize, wait + 1f));
        sequence.Append(transform.DOScale(startSize, wait + 1f));
        sequence.SetLoops(-1);
    }

    public void Scale()
    {

        button.transform.DOScale(targetSize, wait).OnComplete(() =>
        {
            button.transform.DORotate(targetRot, wait).OnComplete(() =>
            {
                button.transform.DOScale(startSize, wait).OnComplete(() =>
                {
                    button.transform.DORotate(startRot, wait);
                });
            });
        });
    }
}
