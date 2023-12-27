using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Sell : MonoBehaviour
{
    public Button addButton;
    public bool IsOnImage;

    public static Sell sell;
    public float scaleFactor = 1.3f;
    public float duration = 1.0f;
    public bool mouseUp;
    private void Awake()
    {
        sell = sell == null ? this : sell;
    }

    public void OnPointExit()
    {
        if (mouseUp)
        {
            IsOnImage = false;
            ObjectList.objectList.DragObjectNow = null;
            MoneyManager.moneyManager.buttonClicked = true;
            MoneyManager.moneyManager.InreaseTotalMoney((float)(addButton.GetComponent<EnoughMoney>().enough * 0.75f));
        }

    }
    public void OnPointEnter()
    {
        if (ObjectList.objectList.DragObjectNow != null)
        {
            IsOnImage = true;
            if (VibratorManager.vibratorManager.mainVibrator)
            {
                Vibrator.Vibrate();
                Vibrator.Vibrate(75);
            }
        }
    }
}
