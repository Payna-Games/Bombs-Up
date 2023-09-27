using DG.Tweening;
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
            ButtonActive();
        }
    }
    private void ButtonActive()
    {
        foreach (GameObject item in GridList.gridListManager.gridList)
        {
            transform.GetComponent<EnoughMoney>().CanInteract = false;
            if (item.GetComponent<GridIsEmpty>().gridObject == null)
            {
                transform.GetComponent<EnoughMoney>().CanInteract = true;
                break;
            }
        }
    }

    private void ObjectType(GameObject item) //item grid objesini temsil eder
    {
        switch (currentObjectType)
        {
            case 1:
                foreach (GameObject itemType in ObjectList.objectList.head) //itemType gridde tutulan objeyi göstermektedir
                {
                    if (!itemType.activeSelf)
                    {
                        DropItemOntoGrid(item, itemType);
                        break;
                    }
                }
                break;
            case 2:
                foreach (GameObject itemType in ObjectList.objectList.body)
                {
                    if (!itemType.activeSelf)
                    {
                        DropItemOntoGrid(item, itemType);
                        break;
                    }
                }
                break;
            case 0:
                foreach (GameObject itemType in ObjectList.objectList.motor)
                {
                    if (!itemType.activeSelf)
                    {
                        DropItemOntoGrid(item, itemType);
                        break;
                    }
                }
                break;
        }
    }

    void DropItemOntoGrid(GameObject item, GameObject itemType)
    {
        item.GetComponent<GridIsEmpty>().gridObject = itemType;
        itemType.SetActive(true);
        item.transform.DOScale(new Vector3(0f, 0f, 0f), 0.01f).SetEase(Ease.OutElastic).OnComplete(() =>
        {
            item.transform.DOScale(new Vector3(2f, 2f, 2f), 0.2f).SetEase(Ease.OutElastic);
        });
        itemType.GetComponent<DragAndDrop>().prevGrid = item;
        itemType.transform.position = item.transform.position;
        item.GetComponent<GridObjectSave>().SaveGridObj();
    }
}
