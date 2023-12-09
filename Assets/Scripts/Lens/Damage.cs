using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Damage : MonoBehaviour
{
    public static Damage damage;

    public event Action FireColor;

    public int addKiloTon;

    // private int downKiloTon;
    [SerializeField] private TextMeshProUGUI damageText;
    
    private ObjectLevel headObjectLevel;
    private ObjectLevel bodyObjectLevel;
    private ObjectLevel motorObjectLevel;
    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float targetScale = 1.5f;
    [SerializeField] private float duration = 1f;
    public bool damageLens;
    private bool savedLens = false;

    private void Awake()
    {
        damage = damage == null ? this : damage;
       
        headObjectLevel = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevel = GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevel = GameObject.Find("Motor").GetComponent<ObjectLevel>();


    }

    private void Start()
    {
        damageLens = false;
        damageText.text = addKiloTon.ToString();
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
                    damageText.text = addKiloTon.ToString();

                }
                else
                {
                    damageText.text = "+" + addKiloTon.ToString();

                }

               TextScaleUpAnim.TextScaleUp(damageText);
                CreateParticle.Create(transform.position);
                savedLens = true;
                Destroy(other.gameObject);
            }

        }

        if (other.CompareTag("Bomb"))
        {
            

            if (!LensWaitTime.LensW.lensActive)
            {
                LensWaitTime.LensW.lensActive = true;
                LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                damageLens = true;
                
                
                other.GetComponent<KiloTonCalculate>().addKTon += addKiloTon;
                other.GetComponent<KiloTonCalculate>().Calculate();




                if (addKiloTon >= 30)
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

                        Transform motorParticle = motorObjectLevel.bombComponent.GetChild(0);
                        motorParticle.gameObject.SetActive(true);
                        motorParticle.GetChild(0).gameObject.SetActive(true);



                    }

                    other.transform.DOScale(Vector3.one * targetScale, 0.5f)
                        .SetEase(Ease.Linear)
                        .OnComplete(() =>
                        {
                            other.transform.DOScale(Vector3.one * initialScale, duration)
                                .SetEase(Ease.OutBounce);
                        });
                }


                MotorFireParticle.motorFireParticle.BombFire();
                gameObject.SetActive(false);
            }




        }


    }

    private void Update()
    {

        if (savedLens)
        {
            CreateParticle.GetLensPosition(transform.position);
            StartCoroutine(SavedLens());
        }

    }

    private IEnumerator SavedLens()
    {
        yield return new WaitForSeconds(1f);
        savedLens = false;

    }
    
}
