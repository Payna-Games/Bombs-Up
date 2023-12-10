using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardToShowText;
    //[SerializeField] private Kill kill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            var multiplier = other.gameObject.name;

            rewardToShowText.text = (MoneyManager.moneyManager.roundedNumber * float.Parse(multiplier)).ToString();
           // Debug.Log("incomeMoney" + MoneyManager.moneyManager.roundedNumber);
        }
    }
}
