using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardToShowText;
     private Animator handAnim;
     float reward;
    [SerializeField] private Transform moneyParticlePosition;


    private void Start()
    {
        
        handAnim = GetComponent<Animator>(); 
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
                double roundedText = Math.Round(reward/ 1000, 1);
                
                rewardToShowText.text = roundedText.ToString() + "k";
            }
            else
            {
                rewardToShowText.text = reward.ToString();

            }
            
           
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
