using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Damage : MonoBehaviour
{
    [SerializeField] private int addKiloTon;
   // private int downKiloTon;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private ParticleSystem waterParticle;
    [SerializeField] private Transform particleTransform;
    private ObjectLevel headObjectLevel;
    private ObjectLevel bodyObjectLevel;
    private ObjectLevel motorObjectLevel;
    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float targetScale = 1.5f;
    [SerializeField] private float duration = 1f;


    private void Awake()
    {
        headObjectLevel = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevel = GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevel = GameObject.Find("Motor").GetComponent<ObjectLevel>();
    }

    private void Start()
    {
        damageText.text =  addKiloTon.ToString();
       // downKiloTon = GetComponent<DamageDown>().addKiloTon;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            if (enabled == true)
            {
                addKiloTon++;
                if (addKiloTon == 0)
                {
                    damageText.text =  addKiloTon.ToString(); 
                
                }
                else
                {
                    damageText.text = "+" + addKiloTon.ToString(); 
                
                }
            
                TextScaleUpAnim.TextScaleUp(damageText);
                Instantiate(waterParticle, particleTransform.position, Quaternion.identity);
                waterParticle.Play();
                Destroy(other.gameObject);
            }
            
        }

        if (other.CompareTag("Bomb"))
        {

            if (addKiloTon > 0)
            {
                if (headObjectLevel.damageLevel < 7)
                {
                    headObjectLevel.damageLevel += 1;
                    headObjectLevel.SetFalse2();
                    headObjectLevel.SetTrue2();
                }
                if (bodyObjectLevel.damageLevel < 7)
                {
                    bodyObjectLevel.damageLevel += 1;
                    bodyObjectLevel.SetFalse2();
                    bodyObjectLevel.SetTrue2();
                }
                if (motorObjectLevel.damageLevel < 7)
                {
                    motorObjectLevel.damageLevel += 1;
                    motorObjectLevel.SetFalse2();
                    motorObjectLevel.SetTrue2();
                }
                StartCoroutine(CloseLensAnim());
                other.GetComponent<KiloTonCalculate>().Calculate();


                other.transform.DOScale(Vector3.one * targetScale, 0.5f)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {

                        other.transform.DOScale(Vector3.one * initialScale, duration)
                            .SetEase(Ease.OutBounce);

                    });
            }
              


        }


    }


    private IEnumerator CloseLensAnim()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);

    }

    // private void Update()
    // {
    //     Debug.Log("downkiloTon" + downKiloTon);
    //     if (downKiloTon ==0)
    //     {
    //         enabled = true;
    //     }
    // }
}

