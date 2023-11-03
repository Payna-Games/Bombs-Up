using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBompRange : MonoBehaviour
{
    public float range;
    private float firstY;
    // Start is called before the first frame update
    void Start()
    {
        firstY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        range = MiniBompManager.miniBompManager.range;
        if (transform.position.y > firstY + range)
        {
            gameObject.SetActive(false);
        }
    }
}
