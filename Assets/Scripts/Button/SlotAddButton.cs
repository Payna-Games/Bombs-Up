using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAddButton : MonoBehaviour
{
    private int currentObjectType;
    public void ObjectLocalize()
    {
        foreach (GameObject item in GridList.gridListManager.gridList)
        {
            if (item.GetComponent<GridIsEmpty>().gridObject == null)
            {
                currentObjectType = Random.Range(0, 3);
                Debug.Log("Oluþan sayý : " + currentObjectType);
                ObjectType(item);
                break;
            }
        }
    }

    private void ObjectType(GameObject item)
    {
        switch (currentObjectType)
        {
            case 1:
                foreach (GameObject itemType in ObjectList.objectList.head)
                {
                    if (!itemType.activeSelf)
                    {
                        item.GetComponent<GridIsEmpty>().gridObject = itemType;
                        itemType.SetActive(true);
                        itemType.GetComponent<DragAndDrop>().prevGrid = item;
                        itemType.transform.position = item.transform.position;
                        item.GetComponent<GridObjectSave>().SaveGridObj();
                        break;
                    }
                }
                break;
            case 2:
                foreach (GameObject itemType in ObjectList.objectList.body)
                {
                    if (!itemType.activeSelf)
                    {
                        item.GetComponent<GridIsEmpty>().gridObject = itemType;
                        itemType.SetActive(true);
                        itemType.GetComponent<DragAndDrop>().prevGrid = item;
                        itemType.transform.position = item.transform.position;
                        item.GetComponent<GridObjectSave>().SaveGridObj();
                        break;
                    }
                }
                break;
            case 0:
                foreach (GameObject itemType in ObjectList.objectList.motor)
                {
                    if (!itemType.activeSelf)
                    {
                        item.GetComponent<GridIsEmpty>().gridObject = itemType;
                        itemType.SetActive(true);
                        itemType.GetComponent<DragAndDrop>().prevGrid = item;
                        itemType.transform.position = item.transform.position;
                        item.GetComponent<GridObjectSave>().SaveGridObj();
                        break;
                    }
                }
                break;
        }
    }
}
