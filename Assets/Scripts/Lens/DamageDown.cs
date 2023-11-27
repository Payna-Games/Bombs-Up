using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageDown : MonoBehaviour
{
    
    
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private Renderer myRenderer;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float targetScale = 1.5f;
    [SerializeField] private float duration = 1f;
    
    private ObjectLevel headObjectLevell;
    private ObjectLevel bodyObjectLevell;
    private ObjectLevel motorObjectLevell;
    
    public int addKiloTon;
    private Damage damage;
    private bool savedLens = false;

    private void Awake()
    {
        headObjectLevell = GameObject.Find("Head").GetComponent<ObjectLevel>();
        bodyObjectLevell= GameObject.Find("Body").GetComponent<ObjectLevel>();
        motorObjectLevell= GameObject.Find("Motor").GetComponent<ObjectLevel>();
    }

    private void Start()
    {
        damageText.text =  addKiloTon.ToString();
        damage = GetComponent<Damage>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniBomb"))
        {
            
            addKiloTon++;
            if (addKiloTon < 0)
            {
                damageText.text =  addKiloTon.ToString(); 
            }
            else if (addKiloTon == 0)
            {
                damageText.text =  addKiloTon.ToString(); 
                
                myRenderer.material = greenMaterial;
                
            }
            else
            {
                damageText.text = "+" + addKiloTon.ToString(); 
                
            }
            
            CreateParticle.Create(transform.position);
            savedLens = true;
            Destroy(other.gameObject);
        }

        if ( other.CompareTag("Bomb") )
        {
           
            if (!LensWaitTime.LensW.lensActive)
            {
                LensWaitTime.LensW.lensActive = true;
                LensWaitTime.LensW.StartCoroutine(LensWaitTime.LensW.LensActive());
                if (savedLens)
                {
                    CreateParticle.ParticleTransform.gameObject.SetActive(false);
                }
                
                if (addKiloTon <= -30)
                {
                    if (headObjectLevell.damageLevel > 0)
                    {
                        headObjectLevell.damageLevel -= 1;
                        headObjectLevell.SetFalse2();
                        headObjectLevell.SetTrue2();
                    }

                    if (bodyObjectLevell.damageLevel > 0)
                    {
                        bodyObjectLevell.damageLevel -= 1;
                        bodyObjectLevell.SetFalse2();
                        bodyObjectLevell.SetTrue2();
                    }

                    if (motorObjectLevell.damageLevel > 0)
                    {
                        motorObjectLevell.damageLevel -= 1;
                        motorObjectLevell.SetFalse2();
                        motorObjectLevell.SetTrue2();
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
        if (addKiloTon == 0)
         {
          enabled =false;
             damage.enabled = true;
    
        }
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


