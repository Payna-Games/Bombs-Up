using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingVibrator : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject[] _vibrator;
    [SerializeField] private Button[] _vibratorButtom;
    void Awake()
    {
        if (PlayerPrefs.GetInt("Vibrator")==0)
        {
            _vibrator[0].SetActive(true);
            _vibrator[1].SetActive(false);
        }
        else
        {
            _vibrator[1].SetActive(true);
            _vibrator[0].SetActive(false);
        }
        _vibratorButtom[0].onClick.AddListener(SettingButton);
        _vibratorButtom[1].onClick.AddListener(VibratorOn);
        _vibratorButtom[2].onClick.AddListener(VibratorOff);
    }


    public void SettingButton()
    {
        if (_settingPanel.activeSelf)
        {
            _settingPanel.SetActive(false);
        }
        else
        {
            _settingPanel.SetActive(true);
        }
    }
    public void VibratorOn()
    {
        _vibrator[1].SetActive(true);
        _vibrator[0].SetActive(false);
        PlayerPrefs.SetInt("Vibrator", 1);
        VibratorManager.vibratorManager.VibratorControl();
    }
    public void VibratorOff()
    {
        _vibrator[0].SetActive(true);
        _vibrator[1].SetActive(false);
        PlayerPrefs.SetInt("Vibrator", 0);
        VibratorManager.vibratorManager.VibratorControl();

    }
}
