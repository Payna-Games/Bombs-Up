using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using YG;


public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardToShowText;
    
     private Animator handAnim;
     public float reward;
    [SerializeField] private Transform moneyParticlePosition;
    public bool adsClicked;

    private void OnEnable() => YandexGame.RewardVideoEvent+= Rewarded; 
    private void OnDisable() => YandexGame.RewardVideoEvent-= Rewarded;                                                            
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
                
                rewardToShowText.text =" $" + roundedText.ToString() + "k";
            }
            else
            {
                rewardToShowText.text = "  $" + reward.ToString();

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

        MoneyManager.moneyManager.buttonClicked = true;
        adsClicked = true;
        
        MoneyManager.moneyManager.InreaseTotalMoney(reward);
        NextLevelButton.nextLevelButton.clicked = true;
     //   MoneyParticle();
       // NextLevelButton.nextLevelButton.NextLevelReward();
        
    }

    // Subscribed reward granting method
    void Rewarded(int id) 
    { 
        // If ID = 1, grant "+100 coins"
        if (id == 0 && !adsClicked && !NextLevelButton.nextLevelButton.clicked)
        {
            GetReward();
            MoneyParticle();
            
        }
        // // If ID = 2, grant "+weapons".
        //  else if (id == 2)
        //  {
        //      AddWeapon();
        //  }
        
    }
    public void ExampleOpenRewardAd(int id)
    {
        if (!adsClicked && !NextLevelButton.nextLevelButton.clicked)
        {
            YandexGame.RewVideoShow(id);
        }
       
    }
    public void MoneyParticle()
    {
        ParticleSystem moneyParticle = Instantiate(GameAssets.i.effects[6], moneyParticlePosition.position, Quaternion.identity); ;
        moneyParticle.Play();
    }
}
