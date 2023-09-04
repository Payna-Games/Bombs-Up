using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridColliderActive : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();

    void Start()
    {
        GameObject[] gridObjects = GameObject.FindGameObjectsWithTag("grid");
        foreach (GameObject gridObject in gridObjects)
        {
            Collider[] objectColliders = gridObject.GetComponentsInChildren<Collider>();
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
