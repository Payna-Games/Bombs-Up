using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDirectionArrow : MonoBehaviour
{
    public Transform target;

    private BompExplode bompExplode;

    private Transform arrow;
    private Transform distanceText;
    private bool loop = true;

    private void Start()
    {
        bompExplode = transform.parent.GetChild(0).GetComponent<BompExplode>();
        bompExplode.explode += BoolFalse;
        arrow = transform;
        distanceText = arrow.GetChild(0).GetChild(0);
    }

    private void Update()
    {
        if (loop)
        {
            var dir = target.position - transform.position;

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

           
            float distance = Vector3.Distance(arrow.position, target.position);
            distanceText.GetComponent<TextMesh>().text = distance.ToString("F0");
        }
    }

    private void BoolFalse(GameObject gameObject)
    {
        loop = false;
    }
}
