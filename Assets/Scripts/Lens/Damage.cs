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

    public int addKiloTon;

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
    public bool damageLens;
    private bool savedLens = false;

    private void Awake()
    {
        damage = damage == null ? this : damage;
        damageLens = false;
        headObjectLevel = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevel = GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevel = GameObject.Find("Motor").GetComponent<ObjectLevel>();


    }

    private void Start()
    {
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
                //waterParticle.Play();
                Destroy(other.gameObject);
            }

        }

        if (other.CompareTag("Bomb"))
        {

            if (!LensWaitTime.lensW.lensActive)
            {
                damageLens = true;
                LensWaitTime.lensW.lensActive = true;
                LensWaitTime.lensW.StartCoroutine(LensWaitTime.lensW.LensActive());
                other.GetComponent<KiloTonCalculate>().Calculate();


                Debug.Log("kiloton");


                if (addKiloTon >= 50)
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

                    other.transform.DOScale(Vector3.one * targetScale, 0.5f)
                        .SetEase(Ease.Linear)
                        .OnComplete(() =>
                        {
                            other.transform.DOScale(Vector3.one * initialScale, duration)
                                .SetEase(Ease.OutBounce);
                        });
                }



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
