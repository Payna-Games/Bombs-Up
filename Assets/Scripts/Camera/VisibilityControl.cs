using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityControl : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Get a reference to the main camera as the camera.
        mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (mainCamera == null)
        {
            // If there is no camera, attempt to find the main camera.
            mainCamera = Camera.main;
        }
        else
        {
            // Check if the object is visible to the camera.
            if (IsVisibleFromCamera(mainCamera))
            {
                // If the camera sees the object, set setActive to true.
                gameObject.SetActive(true);
            }
            else
            {
                // If the camera doesn't see the object, set setActive to false.
                gameObject.SetActive(false);
            }
        }
    }

    // Function to check if the object is visible from the camera.
    bool IsVisibleFromCamera(Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        Collider objectCollider = GetComponent<Collider>();

        return GeometryUtility.TestPlanesAABB(planes, objectCollider.bounds);
    }
}
