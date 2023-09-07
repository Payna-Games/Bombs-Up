using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridColliderActive : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();
    public List<GameObject> bomps;

    void Start()
    {
        GameObject[] gridObjects = GameObject.FindGameObjectsWithTag("grid");
        Collider[] objectColliders;
        foreach (GameObject gridObject in gridObjects)
        {
            objectColliders = gridObject.GetComponentsInChildren<Collider>();
            colliders.AddRange(objectColliders);
        }
        foreach (GameObject item in bomps)
        {
            objectColliders = item.GetComponentsInChildren<Collider>();
            colliders.AddRange(objectColliders);
        }

        SetCollidersActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetCollidersActive(true);
        }
        else
        {
            SetCollidersActive(false);
        }
    }

    private void SetCollidersActive(bool isActive)
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = isActive;
        }
    }
}
