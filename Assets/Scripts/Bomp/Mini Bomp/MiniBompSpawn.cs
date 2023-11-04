using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompSpawn : MonoBehaviour      // kodun new bomps�n head�na at yoksa i�aretli sat�r �al��maz
{
    public FollwChange follwChange;
    private Drop dropCs;
    private bool isSpawn;
    private void Start()
    {
        dropCs = transform.parent.GetComponent<Drop>();     // i�aretli sat�r
        follwChange.changeCamera += SpawnStop;
        dropCs.windPlay += SpawnStart;
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            MiniBompList.miniBompList.miniBomp[0].SetActive(true);
            MiniBompList.miniBompList.miniBomp[0].transform.position = transform.position;
            MiniBompList.miniBompList.miniBomp.RemoveAt(0);
            if (!isSpawn)
                break;
        }
    }
    private void SpawnStart()
    {
        isSpawn = true;
        StartCoroutine(Spawn());
    }
    private void SpawnStop()
    {
        isSpawn = false;
    }
}
