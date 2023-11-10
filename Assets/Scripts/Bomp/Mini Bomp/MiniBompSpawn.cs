using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MiniBompSpawn : MonoBehaviour      // kodun new bomps�n head�na at yoksa i�aretli sat�r �al��maz
{
    public FollwChange follwChange;
    private Drop dropCs;
    public Drop dropCs2;
    private bool isSpawn;
    
    //açılar
    private float x1 = -180;
    private float x = -190f;
    private float y = 180f;
    private float z = 0f;
    private void Start()
    {
        
        follwChange.changeCamera += SpawnStop;        
        if (dropCs2 != null)
        {
            dropCs2.windPlay += SpawnStart;
            if (dropCs2.rotateComplete)
            {
                SpawnStart();
            }
        }
        else
        {
            dropCs = transform.parent.GetComponent<Drop>();     // i�aretli sat�r
            dropCs.windPlay += SpawnStart;
        }
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(MiniBompManager.miniBompManager.spawnSpeed);
            MiniBompList.miniBompList.miniBomp[0].SetActive(true);
            Recoil();
            MiniBompList.miniBompList.miniBomp[0].transform.position = transform.position;
            MiniBompList.miniBompList.miniBomp.RemoveAt(0);
            
            if (!isSpawn)
                break;
        }
    }
    public void SpawnStart()
    {
        isSpawn = true;
        StartCoroutine(Spawn());
    }
    private void SpawnStop()
    {
        isSpawn = false;
    }

    private void Recoil()
    
    {
        Quaternion firstRotation = Quaternion.Euler(x1, y, z);
        Quaternion recoil = Quaternion.Euler(x, y, z);

        transform.parent.DORotateQuaternion(recoil, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
           transform.parent.DORotateQuaternion(firstRotation, 0.2f).SetEase(Ease.Linear);
        });
    }
}
