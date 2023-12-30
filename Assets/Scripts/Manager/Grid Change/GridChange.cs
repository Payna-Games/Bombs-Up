using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp.GameUtils;

public class GridChange : MonoBehaviour
{
    public GameObject grid4x2;
    public GameObject grid3x3;

    private void Awake()
    {
        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            grid4x2.SetActive(true);
            GridList.gridListManager.gridList.Clear();
            for (int i = 1; i < grid4x2.transform.childCount; i++)  // 4x2 de ilk eleman grid h�cresi de�il o sebeple 0 de�il 1den ba�lad� d�ng�
            {
                GridList.gridListManager.gridList.Add(grid4x2.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            grid3x3.SetActive(true);
            GridList.gridListManager.gridList.Clear();
            for (int i = 0; i < grid3x3.transform.childCount-1; i++)  // 3x3 de son eleman grid h�cresi de�il o sebeple -1 koydum biti� de�erine
            {
                GridList.gridListManager.gridList.Add(grid4x2.transform.GetChild(i).gameObject);
            }
        }
    }
}
