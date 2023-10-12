using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    public Transform bomp;

    private bool conditionMet = false;
    private int repeatCount = 5;
    private float repeatInterval = 0.5f;

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

            // Belirli bir süre aralýðý beklemek için yield kullan
            
        }
    }

    private void SetKinematicForAllRigidbodies(bool isKinematic)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Pieces");
        foreach (GameObject obj in taggedObjects)
        {
            // GameObject'in üzerinde Rigidbody bileþeni var mý kontrol et
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Rigidbody'nin "isKinematic" özelliðini belirli deðere ayarla
                rb.isKinematic = isKinematic;
            }
        }
    }
}
