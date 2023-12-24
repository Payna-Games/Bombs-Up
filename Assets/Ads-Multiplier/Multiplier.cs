using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardToShowText;
     private Animator handAnim;
     public float reward;
    [SerializeField] private Transform moneyParticlePosition;
    public bool adsClicked;


    private void Start()
    {
        
        handAnim = GetComponent<Animator>();
        adsClicked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            string multiplier = other.gameObject.name;

            
            reward = (MoneyManager.moneyManager.roundedNumber * float.Parse(multiplier));
            //int roundedReward = (int)reward;
           
            if (reward >= 1000)
            {
                double roundedText = Math.Round(reward/ 1000, 0);
                
                rewardToShowText.text ="Claim "+  "\n  $" + roundedText.ToString() + "k";
            }
            else
            {
                rewardToShowText.text = "$" + reward.ToString();

            }
            
           
        }
    }

    public void StopHandAnim()
    {
        if (reward >= 1000)
        {
            double roundedText = Math.Round(reward / 1000, 1);

            rewardToShowText.text = "$" + roundedText.ToString() + "k";
        }
        else
        {
            rewardToShowText.text = "$" + reward.ToString();

        }
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
        adsClicked = true;
        MoneyManager.moneyManager.InreaseTotalMoney(reward);
        
        //Debug.Log("GetReward");
    }
});
        MoneyParticle();
        NextLevelButton.nextLevelButton.NextLevelReward();
    }

    public void MoneyParticle()
    {
        ParticleSystem moneyParticle = Instantiate(GameAssets.i.effects[6], moneyParticlePosition.position, Quaternion.identity); ;
        moneyParticle.Play();
    }
}
