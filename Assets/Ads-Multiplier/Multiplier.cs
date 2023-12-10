using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardToShowText;
     private Animator handAnim;
    private float reward;


    private void Start()
    {
        
        handAnim = GetComponent<Animator>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            var multiplier = other.gameObject.name;

            reward = (MoneyManager.moneyManager.roundedNumber * float.Parse(multiplier));
            rewardToShowText.text = reward.ToString();
           
        }
    }

    public void StopHandAnim()
    {
        rewardToShowText.text = reward.ToString();
        //handAnim.StopPlayback();
        handAnim.enabled = false;
    }

    public void GetReward()
    {
        YsoCorp.GameUtils.YCManager.instance.adsManager.ShowRewarded
((bool ok) => {
    if (ok)
    {
        MoneyManager.moneyManager.buttonClicked = true;
        MoneyManager.moneyManager.InreaseTotalMoney(reward);
        NextLevelButton.nextLevelButton.NextLevelReward();
        Debug.Log("GetReward");
    }
});
    }
}
