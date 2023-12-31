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
    [SerializeField] private TextMeshProUGUI getText;
   [SerializeField] private Multiplier multiplier;
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
           // Debug.Log("Increase if");
        }
        if(!multiplier.adsClicked )
        {
            roundedNumber = (int)Math.Round(otherMoney);
            double getTextRounded = otherMoney / 1000;
            string numberAsString = getTextRounded.ToString();
            int index = numberAsString.IndexOf(',') + 4;
            string result = numberAsString.Substring(0, index);

            nextLevelMoney.text = roundedNumber.ToString();
            if (otherMoney >= 1000)
            {
                getText.text = "Get " + "$" + result+ "k";
            }
            else 
            {
                getText.text = "Get " + "$" + roundedNumber.ToString() + "k";
            }
            

            //StartCoroutine(CounterPrint(roundedNumber));
            // Debug.Log("Increase else");
        }
        else if (multiplier.adsClicked)
        {
            roundedNumber = (int)Math.Round(otherMoney);
            nextLevelMoney.text ="$" +multiplier.reward.ToString();
            getText.text = "$" + multiplier.reward.ToString();
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
