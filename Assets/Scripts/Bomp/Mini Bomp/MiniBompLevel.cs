using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompLevel : MonoBehaviour
{
    public Transform mainBomp;
    private void Start()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform == transform.parent.GetChild(i).transform)
            {
                SetFalse();
                SetTrue(mainBomp.GetChild(i).GetComponent<ObjectLevel>().objectLevel);
            }
        }
    }
    public void SetFalse()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            if (child != transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void SetTrue(int objectLevel)
    {
        transform.GetChild(objectLevel).gameObject.SetActive(true);
    }
}
