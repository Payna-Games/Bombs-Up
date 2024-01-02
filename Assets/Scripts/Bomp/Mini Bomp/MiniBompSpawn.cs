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
    [SerializeField] private GameObject miniBombParent;

    //açılar
    private float x1 = -180;
    private float x = -182f;
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
        // if(!LastLensAfter.lastLensAfter.lastLensPassed)
        //  {
        while (true)
        {
            if (!isSpawn)
                break;
            yield return new WaitForSeconds(MiniBompManager.miniBompManager.spawnSpeed);
            MiniBompList.miniBompList.miniBomp[0].SetActive(true);
            // Recoil();
            MiniBompList.miniBompList.miniBomp[0].transform.position = transform.position;
            MiniBompList.miniBompList.miniBomp.RemoveAt(0);



        }
        //  }   
    }
    public void SpawnStart()
    {

        isSpawn = true;
        StartCoroutine(Spawn());
    }
    private void SpawnStop()
    {
        isSpawn = false;
        if (miniBombParent != null)
        {
            miniBombParent.SetActive(false);
            follwChange.changeCamera -= SpawnStop;
        }

    }

    //private void Recoil()

    //{
    //    Quaternion firstRotation = Quaternion.Euler(x1, y, );
    //    Quaternion recoil = Quaternion.Euler(x, y, z);

    //    transform.parent.DORotateQuaternion(recoil, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
    //    {
    //       transform.parent.DORotateQuaternion(firstRotation, 0.1f).SetEase(Ease.Linear);
    //    });
    //}
}
