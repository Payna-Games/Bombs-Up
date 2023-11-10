using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextScaleUpAnim : MonoBehaviour
{
    public static void TextScaleUp(TextMeshProUGUI text)
    {
        text.transform.DOScale(Vector3.one * 1.5f, 0.3f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                text.transform.DOScale(Vector3.one * 1f, 0.3f)
                    .SetEase(Ease.Linear);
            });
    }
}
