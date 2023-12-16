using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
public class Sell : MonoBehaviour
{
    public Button addButton;
    public bool IsOnImage;

    public static Sell sell;
    private Vector3 normalSize;
    public float scaleFactor = 1.3f;
    public float duration = 1.0f;
    private RectTransform rectTransform;
    Vector2 targetSize;

    private void Awake()
    {
        sell = sell == null ? this : sell;
        //rectTransform = GetComponent<RectTransform>();
        //normalSize = transform.localScale;
        //targetSize = rectTransform.sizeDelta * scaleFactor;
    }

    public void OnPointExit()
    {
        IsOnImage = false;
        MoneyManager.moneyManager.buttonClicked = true;
        MoneyManager.moneyManager.InreaseTotalMoney((float)(addButton.GetComponent<EnoughMoney>().enough * 0.75f));
    }
    public void OnPointEnter()
    {
        IsOnImage = true;
        if (VibratorManager.vibratorManager.mainVibrator)
        {
            Vibrator.Vibrate();
            Vibrator.Vibrate(200);
        }
    }
}
