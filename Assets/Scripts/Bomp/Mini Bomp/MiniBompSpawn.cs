using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompSpawn : MonoBehaviour      // kodun new bomps�n head�na at yoksa i�aretli sat�r �al��maz
{
    public FollwChange follwChange;
    private Drop dropCs;
    public Drop dropCs2;
    private bool isSpawn;
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
}
