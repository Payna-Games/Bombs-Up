using System;
using TMPro;
using UnityEngine;



public class MoneyManager : TextPrint
{
    public long totalMoney = 0;

    public static MoneyManager moneyManager;
    [SerializeField] private TextMeshProUGUI nextLevelMoney;

    private void Awake()
    {
        moneyManager = moneyManager == null ? this : moneyManager;
    }
    private void Start()
    {
        string i = "405";
        if (PlayerPrefs.HasKey(transform.name))
        {
            i = PlayerPrefs.GetString(transform.name);
        }
        InreaseTotalMoney(System.Convert.ToInt64(i));
    }
    private void OnDisable()
    {
        PlayerPrefs.SetString(transform.name, totalMoney.ToString());
    }

    public void InreaseTotalMoney(float otherMoney)
    {
        totalMoney += (long)otherMoney;
        int roundedNumber = (int)Math.Round(otherMoney);
        nextLevelMoney.text =  roundedNumber.ToString();
        ButtonPrint(totalMoney);
    }

    public void DecreaseTotalMoney(float otherMoney)
    {
        totalMoney -= (long)otherMoney;
        ButtonPrint(totalMoney);
    }
}
