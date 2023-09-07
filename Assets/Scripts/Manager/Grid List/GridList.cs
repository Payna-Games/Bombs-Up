using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridList : MonoBehaviour
{
    public static GridList gridListManager;

    public List<GameObject> gridList;

    private void Awake()
    {
        gridListManager = gridListManager == null ? this : gridListManager;
    }
}