using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectSave : MonoBehaviour
{
    public GameObject gridObj;
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            if (PlayerPrefs.GetString(transform.name) != "")
            {
                string obj = PlayerPrefs.GetString(transform.name);
                gridObj = GameObject.Find(obj);
                Debug.Log("Dotween Güncelle Süleyman bey");
                if (gridObj  == true)
                {
                    Debug.Log("Aktif");
                }
                else
                {
                    Debug.Log("Degil");
                }
                transform.GetComponent<GridIsEmpty>().gridObject = gridObj;
            }
        }
    }

    public void SaveGridObj()
    {
        string objName;
        if (transform.GetComponent<GridIsEmpty>().gridObject == null)
            objName = "";
        else
            objName = transform.GetComponent<GridIsEmpty>().gridObject.name;
        PlayerPrefs.SetString(transform.name, objName);
    }
}
