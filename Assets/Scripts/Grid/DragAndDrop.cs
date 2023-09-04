using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 thisPos;

    private GameObject prevGrid = null;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        thisPos = transform.position;
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y * 1.3f, newPosition.z);

    }
    private void OnMouseUp()
    {
        DragPos();
    }

    private void DragPos()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("grid"))
            {
                IsEmpty(collider.gameObject);
            }
        }
        if (colliders.Length == 1)
        {
            transform.position = thisPos;
        }
    }
    private void IsMerge(GameObject colliderObj)
    {
        GameObject gridObject = colliderObj.GetComponent<GridIsEmpty>().gridObject;
        if (gridObject.tag == transform.tag && gridObject.GetComponent<ObjectLevel>().objectLevel == transform.GetComponent<ObjectLevel>().objectLevel)
        {
            gridObject.GetComponent<ObjectLevel>().LevelUp();
            gridObject.GetComponent<ObjectLevel>().SetFalse();
            gridObject.GetComponent<ObjectLevel>().SetTrue();
            gameObject.SetActive(false);
            PrevGridNull();
        }
        else
            transform.position = thisPos;
    }

    private void IsEmpty(GameObject colliderObj)
    {
        if (colliderObj.GetComponent<GridIsEmpty>().gridObject == null)
        {
            colliderObj.GetComponent<GridIsEmpty>().gridObject = this.gameObject;
            transform.position = colliderObj.transform.position;

            if (prevGrid != null)
            {
                PrevGridNull();
            }
            prevGrid = colliderObj;
        }
        else
        {
            IsMerge(colliderObj);
        }
    }
    private void PrevGridNull()
    {
        prevGrid.GetComponent<GridIsEmpty>().gridObject = null;
        prevGrid = null;
    }
}