using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 thisPos;

    public GameObject prevGrid = null;

    private float mZCoord;
    private float elevation;
    public float tiltAngle;
    public Vector3 firstPosition;
    private Vector3 offset;
    private Vector3 mouseWorldPos;

    private float mouseElevaiton = 1.5f;


    //private Vector3 GetMousePos()
    //{
    //    //return Camera.main.WorldToScreenPoint(transform.position);
    //}
    public Vector3 GetMouseWorldPosition()
    {

        Vector3 mousePos = Input.mousePosition;

        mousePos.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        offset = transform.position - GetMouseWorldPosition();
        firstPosition = transform.position;

        thisPos = transform.position;
        //mousePosition = Input.mousePosition - GetMousePos();
    }


    private void OnMouseDrag()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        //Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        //transform.position = new Vector3(newPosition.x, newPosition.y * 1.15f, newPosition.z);

        mouseWorldPos = GetMouseWorldPosition() + offset;
        elevation = (transform.position.z - firstPosition.z) * Mathf.Tan(tiltAngle * Mathf.Deg2Rad);
        mouseWorldPos.y = elevation + firstPosition.y + mouseElevaiton;

        transform.position = mouseWorldPos;

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
                break;
            }
            else if ((collider.CompareTag("B_Head") || collider.CompareTag("B_Body") || collider.CompareTag("B_Engine")) )
            {
                BombObjChange(collider.gameObject);
            }
        }
        if (colliders.Length == 1)
        {
            PrevPos();
        }
    }

    private void BombObjChange(GameObject gameObject)
    {
        int levelThis = this.gameObject.GetComponent<ObjectLevel>().objectLevel;
        int levelColliderObj = gameObject.GetComponent<ObjectLevel>().objectLevel;
        if (levelThis >= levelColliderObj)
        {
            switch (gameObject.tag)
            {
                case "B_Head":
                    if (this.gameObject.CompareTag("Head"))
                    {
                        if (levelThis == levelColliderObj)
                            gameObject.GetComponent<ObjectLevel>().LevelUp();
                        else
                            gameObject.GetComponent<ObjectLevel>().LevelUp(levelThis);
                        gameObject.GetComponent<ObjectLevel>().SetFalse();
                        gameObject.GetComponent<ObjectLevel>().SetTrue();
                    }

                    break;
                case "B_Body":
                    if (this.gameObject.CompareTag("Body"))
                    {
                        if (levelThis == levelColliderObj)
                            gameObject.GetComponent<ObjectLevel>().LevelUp();
                        else
                            gameObject.GetComponent<ObjectLevel>().LevelUp(levelThis);
                        gameObject.GetComponent<ObjectLevel>().SetFalse();
                        gameObject.GetComponent<ObjectLevel>().SetTrue();
                    }

                    break;
                case "B_Engine":
                    if (this.gameObject.CompareTag("Motor"))
                    {
                        if (levelThis == levelColliderObj)
                            gameObject.GetComponent<ObjectLevel>().LevelUp();
                        else
                            gameObject.GetComponent<ObjectLevel>().LevelUp(levelThis);
                        gameObject.GetComponent<ObjectLevel>().SetFalse();
                        gameObject.GetComponent<ObjectLevel>().SetTrue();
                    }

                    break;
            }
            if (levelColliderObj != levelThis)  
                LowerObjLevel(levelColliderObj);
            else
            {
                this.gameObject.SetActive(false);
                PrevGridNull();
            }
        }
        PrevPos();
    }

    private void LowerObjLevel(int level)
    {
        gameObject.GetComponent<ObjectLevel>().LevelDown(level);
        gameObject.GetComponent<ObjectLevel>().SetFalse();
        gameObject.GetComponent<ObjectLevel>().SetTrue();
    }

    private void IsMerge(GameObject colliderObj)
    {
        GameObject gridObject = colliderObj.GetComponent<GridIsEmpty>().gridObject;
        if (gridObject.name == transform.name)
            PrevPos();
        else if (gridObject.tag == transform.tag && gridObject.GetComponent<ObjectLevel>().objectLevel == transform.GetComponent<ObjectLevel>().objectLevel)
        {
            gridObject.GetComponent<ObjectLevel>().LevelUp();
            gridObject.GetComponent<ObjectLevel>().SetFalse();
            gridObject.GetComponent<ObjectLevel>().SetTrue();
            gameObject.SetActive(false);
            PrevGridNull();
        }
        else
            PrevPos();
    }

    public void PrevPos()
    {
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