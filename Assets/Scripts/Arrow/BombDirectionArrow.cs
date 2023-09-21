using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDirectionArrow : MonoBehaviour
{
    public Transform target; // Hedef obje (stadyum gibi)

    private Transform arrow; // Ok objesi
    private Transform distanceText; // Mesafe metni objesi

    private void Start()
    {
        arrow = transform; // Ok, bombanýn ilk child'i olarak kabul edildi.
        distanceText = arrow.GetChild(0).GetChild(0); // Mesafe metni, okun ilk child'i olarak kabul edildi.
    }

    private void Update()
    {
        // Bombanýn konumu ve hedefin konumu arasýndaki mesafeyi hesapla
        float distance = Vector3.Distance(arrow.position, target.position);

        arrow.LookAt(target);

        //Vector3 targetDirection = target.position - transform.position;
        //Vector3 upVector = Vector3.back;

        //Quaternion rotation = Quaternion.LookRotation(targetDirection, upVector);
        //transform.rotation = new Quaternion(transform.rotation.x + 90.0f, transform.rotation.y, rotation.z, 1.0f);

        // Mesafe metnini güncelle
        distanceText.GetComponent<TextMesh>().text = distance.ToString("F0"); // Metreyi metin olarak 
    }
}
