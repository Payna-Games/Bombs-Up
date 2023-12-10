using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MoneyManager : TextPrint
{
    public long totalMoney = 0;

    public static MoneyManager moneyManager;
    [SerializeField] private TextMeshProUGUI nextLevelMoney;
    public bool buttonClicked;
    public int roundedNumber;

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
        buttonClicked = true;
        InreaseTotalMoney(System.Convert.ToInt64(i));
    }
    private void OnDisable()
    {
        PlayerPrefs.SetString(transform.name, totalMoney.ToString());
    }

    public void InreaseTotalMoney(float otherMoney)
    {
        if (buttonClicked)
        {
            buttonClicked = false;
            totalMoney += (long)otherMoney;
        }
        else
        {
            roundedNumber = (int)Math.Round(otherMoney);
            nextLevelMoney.text = roundedNumber.ToString();
            //StartCoroutine(CounterPrint(roundedNumber));
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
    //IEnumerator CounterPrint(int roundedNumber)
    //{
    //    int increaseRate = roundedNumber / 50;// increase rate = art?? oran?
    //    for (int i = 0; i <= roundedNumber; i+=increaseRate)
    //    {
    //        yield return new WaitForSeconds(0.001f);
    //        nextLevelMoney.text = i.ToString();
    //    }
    //    nextLevelMoney.text = roundedNumber.ToString();
    //}
}
