using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static ObjectList objectList;

    public List<GameObject> head;
    public List<GameObject> body;
    public List<GameObject> motor;

    public GameObject DragObject;
    public GameObject DragObjectNow;    // þuanda tuttuðu obje 
    public bool gameObjectsFalse;

    private void Start()
    {
        objectList = objectList == null ? this : objectList;

        
        foreach (GameObject item in head)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in body)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in motor)
        {
            item.SetActive(false);
        }

        for(int i=0; i<9; i++)
        {
            GridList.gridListManager.gridList[i].GetComponent<SaveObj>().Save();
        }
        
        
    }

    
}
