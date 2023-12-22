using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnVibrator : MonoBehaviour
{
    public static BtnVibrator btnVibrator;
    public bool onVibrator;
    private void Awake()
    {
        btnVibrator = btnVibrator == null ? this : btnVibrator;
    }

    public void ButtonVibrator()
    {
        if (VibratorManager.vibratorManager.mainVibrator)
        {
            Vibrator.Vibrate();
            Vibrator.Vibrate(100);
        }
    }
}
