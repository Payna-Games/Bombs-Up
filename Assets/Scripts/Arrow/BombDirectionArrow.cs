using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDirectionArrow : MonoBehaviour
{
    public Transform target;

    private Transform arrow;
    private Transform distanceText;

    private void Start()
    {
        arrow = transform; 
        distanceText = arrow.GetChild(0).GetChild(0);
    }

    private void Update()
    {
        float distance = Vector3.Distance(arrow.position, target.position);

        arrow.LookAt(target);
        distanceText.GetComponent<TextMesh>().text = distance.ToString("F0"); // Metreyi metin olarak 
    }
}
