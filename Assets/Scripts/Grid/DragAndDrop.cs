using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 thisPos;

    public bool onVibrator = true;
    public GameObject prevGrid = null;
    public event Action tutorialMerge;
    public event Action<int> tutorialBompMerge;

    public ParticleSystem mergeParticle;
    public ParticleSystem rocketMergeParticle;

    private float mZCoord;
    private float elevation;
    public float tiltAngle;
    public Vector3 firstPosition;
    private Vector3 offset;
    private Vector3 mouseWorldPos;

    private float mouseElevaiton = 1.5f;

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnMouseDown()
    {
        ObjectList.objectList.DragObject = this.gameObject;

        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        offset = transform.position - GetMouseWorldPosition();
        firstPosition = transform.position;

        thisPos = transform.position;
    }

    private void OnMouseDrag()
    {
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
            else if ((collider.CompareTag("B_Head") && gameObject.CompareTag("Head")) || (collider.CompareTag("B_Body") && gameObject.CompareTag("Body")) || (collider.CompareTag("B_Engine") && gameObject.CompareTag("Motor")))
            {
                BombObjChange(collider.gameObject);
            }
            else
                PrevPos();
        }
        if (Sell.sell.IsOnImage)
        {
            SellObject();
        }
        if (colliders.Length == 1)
        {
            PrevPos();
        }
    }

    private void SellObject()
    {
        transform.GetComponent<ObjectLevel>().objectLevel = 0;
        transform.GetComponent<DragAndDrop>().PrevGridNull();
        gameObject.SetActive(false);

        SlotAddButton.slotAddButton.ButtonActive();
        float money = (float)SlotAddButton.slotAddButton.gameObject.GetComponent<EnoughMoney>().enough;
        MoneyManager.moneyManager.InreaseTotalMoney(money - (money / 10));
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
                        ReserObject(gameObject);
                    }

                    break;
                case "B_Body":
                    if (this.gameObject.CompareTag("Body"))
                    {
                        if (levelThis == levelColliderObj)
                            gameObject.GetComponent<ObjectLevel>().LevelUp();
                        else
                            gameObject.GetComponent<ObjectLevel>().LevelUp(levelThis);
                        ReserObject(gameObject);
                        tutorialBompMerge?.Invoke(gameObject.GetComponent<ObjectLevel>().objectLevel);
                    }

                    break;
                case "B_Engine":
                    if (this.gameObject.CompareTag("Motor"))
                    {
                        if (levelThis == levelColliderObj)
                            gameObject.GetComponent<ObjectLevel>().LevelUp();
                        else
                            gameObject.GetComponent<ObjectLevel>().LevelUp(levelThis);
                        ReserObject(gameObject);
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
    private void ReserObject(GameObject gameObject)
    {
        if (onVibrator)
        {
            Vibrator.Vibrate();
            Vibrator.Vibrate(200);
        }
        Vector3 bompParticPos = new Vector3(gameObject.transform.position.x + 2.29f, gameObject.transform.position.y - 4.38f, gameObject.transform.position.z - 1.5f);
        ParticleSystem particleRocketMerge = Instantiate(rocketMergeParticle, bompParticPos, Quaternion.identity);
        particleRocketMerge.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
        particleRocketMerge.Play();
        gameObject.transform.parent.GetComponent<KiloTonCalculate>().Calculate();
        gameObject.GetComponent<ObjectLevel>().SetFalse();
        gameObject.GetComponent<ObjectLevel>().SetTrue();
        this.transform.GetComponent<ObjectLevel>().objectLevel = 0;
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
            tutorialMerge?.Invoke();
            gridObject.GetComponent<ObjectLevel>().LevelUp();
            ParticleSystem particleMerge = Instantiate(mergeParticle, gridObject.transform.position, Quaternion.identity);
            ParticleSystem.MainModule mainModule = particleMerge.main;
            mainModule.startSize = 3f;
            particleMerge.Play();
            transform.GetComponent<ObjectLevel>().objectLevel = 0;
            gridObject.GetComponent<ObjectLevel>().SetFalse();
            gridObject.GetComponent<ObjectLevel>().SetTrue();
            gameObject.SetActive(false);
            PrevGridNull();
            SlotAddButton.slotAddButton.ButtonActive();
        }
        else
            PrevPos();
        if (onVibrator)
        {
            Vibrator.Vibrate();
            Vibrator.Vibrate(200);
        }
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
            colliderObj.GetComponent<GridObjectSave>().SaveGridObj();
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
    public void PrevGridNull()
    {
        prevGrid.GetComponent<GridIsEmpty>().gridObject = null;
        prevGrid.GetComponent<GridObjectSave>().SaveGridObj();
        prevGrid = null;
    }
}