using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp.GameUtils;

public class GridChange : MonoBehaviour
{
    public GridList gridListScript;
    public GameObject grid4x2;
    public GameObject grid3x3;

    private void Awake()
    {
        gridListScript.Singleton();
        if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            grid3x3.SetActive(true);
            grid4x2.SetActive(false);
            GridList.gridListManager.gridList.Clear();
            for (int i = 0; i < grid3x3.transform.childCount - 1; i++)  // 3x3 de son eleman grid hücresi değil o sebeple -1 koydum bitiş değerine
            {
                GridList.gridListManager.gridList.Add(grid3x3.transform.GetChild(i).gameObject);
            }
        }

        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            grid4x2.SetActive(true);
            grid3x3.SetActive(false);
            GridList.gridListManager.gridList.Clear();
            for (int i = 1; i < grid4x2.transform.childCount; i++)  // 4x2 de ilk eleman grid hücresi değil o sebeple 0 değil 1den başladı döngü
            {
                GridList.gridListManager.gridList.Add(grid4x2.transform.GetChild(i).gameObject);
            }
        }
    }
}    
