using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibratorManager : MonoBehaviour
{
    public static VibratorManager vibratorManager;
    public bool mainVibrator;
    private void Awake()
    {
        vibratorManager = vibratorManager == null ? this : vibratorManager;
        VibratorControl();
    }
    public void VibratorControl()
    {
        if (PlayerPrefs.GetInt("Vibrator") == 0)
        {
            mainVibrator = true;
        }
        else
        {
            mainVibrator = false;
        }
    }

}
