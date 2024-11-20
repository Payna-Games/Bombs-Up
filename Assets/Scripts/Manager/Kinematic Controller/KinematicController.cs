using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    public Transform bomp;

    private bool conditionMet = false;
    private int repeatCount = 5;


    private void Start()
    {
        bomp.GetComponent<BompExplode>().explodeBefor += KinematicController_explodeBefor;
    }

    private void KinematicController_explodeBefor()
    {
        conditionMet = true;
    }

    private void Update()
    {
        if (conditionMet)
        {
            StartCoroutine(RepeatKinematicSetter());
            conditionMet = false;
        }
    }

    private IEnumerator RepeatKinematicSetter()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            yield return new WaitForSeconds(1);
            SetKinematicForAllRigidbodies(true);

            // Belirli bir s�re aral��� beklemek i�in yield kullan
            
        }
    }

    private void SetKinematicForAllRigidbodies(bool isKinematic)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Pieces");
        foreach (GameObject obj in taggedObjects)
        {
            // GameObject'in �zerinde Rigidbody bile�eni var m� kontrol et
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Rigidbody'nin "isKinematic" �zelli�ini belirli de�ere ayarla
                rb.isKinematic = isKinematic;
            }
        }
    }
}
