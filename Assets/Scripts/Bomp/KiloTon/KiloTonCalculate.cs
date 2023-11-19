using System;
using UnityEngine;

public class KiloTonCalculate : MonoBehaviour
{
    public static KiloTonCalculate kiloTonCalculate;

    
    public int addKTon;
    public int KiloTon;
    public event Action<int> kTon;
    private void Awake()
    {
        kiloTonCalculate = kiloTonCalculate == null ? this : kiloTonCalculate;
    }
    void Start()
    {
        Calculate();
    }
    private void OnEnable()
    {
        Calculate();
    }

    public void Calculate()
    {
        KiloTon = 100;
        for (int i = 0; i < 3; i++)
        {
            if (transform.GetChild(i).GetComponent<ObjectLevel>().objectLevel < transform.GetChild(i).GetComponent<ObjectLevel>().damageLevel)
            {
                for (int j = transform.GetChild(i).GetComponent<ObjectLevel>().damageLevel; j > 0; j--)
                {
                    KiloTon += 10 + j * 10;
                }
            }
            else
            {
                for (int j = transform.GetChild(i).GetComponent<ObjectLevel>().objectLevel; j > 0; j--)
                {
                    KiloTon += 10 + j * 10;
                }
            }

        }

        for (int i = 0; i < transform.GetChild(4).childCount; i++)
        {
            if (transform.GetChild(4).GetChild(i).gameObject.activeSelf)
            {
                KiloTon += 100;
            }
        }
        KiloTon += addKTon;
        //if (Damage.damage != null && Damage.damage.damageLens)
        //{
        //    KiloTon += Damage.damage.addKiloTon;
        //    kTon?.Invoke(KiloTon);
        //    Damage.damage.damageLens = false;
        //}
        kTon?.Invoke(KiloTon);
        
       
    }


}
