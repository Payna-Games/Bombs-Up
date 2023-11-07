using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiloTonCalculate : MonoBehaviour
{
    public int KiloTon;
    // Start is called before the first frame update
    void Start()
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

        for (int i = 0; i < transform.GetChild(8).childCount; i++)
        {
            if (transform.GetChild(8).GetChild(i).gameObject.activeSelf)
            {
                KiloTon += 100;
            }
        }
    }
}
