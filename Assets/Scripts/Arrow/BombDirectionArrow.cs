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
        bompExplode = transform.parent.GetComponent<BompExplode>();
        bompExplode.explode += BoolFalse;
        arrow = transform;
        distanceText = arrow.GetChild(0).GetChild(0);
    }

    private void Update()
    {
        if (loop)
        {
            //Vector3 direction = target.position - transform.position;
                        
            //Vector3 lookDirection = new Vector3(transform.position.x + 90 - direction.x, transform.position.x - 90, 0);

            ////transform.rotation = Quaternion.LookRotation(lookDirection);
            //float distance = direction.magnitude;

            // Uzaklýðý TextMesh'e yazdýrýn
            //distanceText.GetComponent<TextMesh>().text = distance.ToString("F1");

            float distance = Vector3.Distance(arrow.position, target.position);

            arrow.LookAt(target);
            distanceText.GetComponent<TextMesh>().text = distance.ToString("F0"); // Metreyi metin olarak 
        }
    }

    private void BoolFalse(GameObject gameObject)
    {
        loop = false;
    }
}
