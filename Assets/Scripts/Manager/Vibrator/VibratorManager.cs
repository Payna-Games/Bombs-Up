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
        mainVibrator = false;
    }
}
