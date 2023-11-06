using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCalculate : MonoBehaviour
{
    public int TotalCount;
    public void CreateCalculate(string kind, int value)
    {
        switch (kind)
        {
            case "/":
                TotalCount /= value;
                TotalCount += 1;
                break;
            case "*":
                TotalCount *= value;
                break;
            case "-":
                TotalCount -= value;
                break;
            case "+":
                TotalCount += value;
                break;
            default:
                break;
        }
    }
    public void ActiveObj()
    {
        for (int i = 0; i < TotalCount-1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DeActiveObj()
    {
        for (int i = transform.childCount-1; i > TotalCount-2; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
