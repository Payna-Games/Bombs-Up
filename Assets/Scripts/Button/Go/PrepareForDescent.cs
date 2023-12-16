using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForDescent : MonoBehaviour
{
    public List<GameObject> ActiveObj;

    public void MakeFalseActive()
    {
        foreach (GameObject item in ActiveObj)
        {
            item.SetActive(false);
        }
    }
}
