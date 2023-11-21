using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MoneyManager : TextPrint
{
    public long totalMoney = 0;

    public static MoneyManager moneyManager;
    [SerializeField] private TextMeshProUGUI nextLevelMoney;
    public bool buttonClicked;

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
        buttonClicked = false;
    }
    private void OnDisable()
    {
        PlayerPrefs.SetString(transform.name, totalMoney.ToString());
    }

    public void InreaseTotalMoney(float otherMoney)
    {
       
        int roundedNumber = (int)Math.Round(otherMoney);
       
        nextLevelMoney.text =  roundedNumber.ToString();
        
        if (buttonClicked)
        {
            totalMoney += (long)otherMoney;
           
        }
        ButtonPrint(totalMoney);
        PlayerPrefs.SetString(transform.name, totalMoney.ToString());
    }

    public void DecreaseTotalMoney(float otherMoney)
    {
        totalMoney -= (long)otherMoney;
        ButtonPrint(totalMoney);
        PlayerPrefs.SetString(transform.name, totalMoney.ToString());
    }

    private void Update()
    {
        
    }
}
