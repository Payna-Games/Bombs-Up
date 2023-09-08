using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset; // Baþlangýçta nesneye týkladýðýnýz konumu saklayacak deðiþken.
    private bool isDragging = false; // Nesneyi sürükleyip sürüklememe durumunu belirleyecek deðiþken.

    void OnMouseDown()
    {
        // Nesneye týkladýðýnýzda baþlangýç konumunu kaydedin ve sürükleme iþlemini baþlatýn.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Fare düðmesini býraktýðýnýzda sürükleme iþlemini durdurun.
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Fare pozisyonunu dünya koordinatlarýna dönüþtürün ve nesneyi taþýyýn.
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = transform.position.z; // Nesnenin z konumunu sabit tutmak için.

            // Nesneyi yeni konumuna taþýyýn.
            transform.position = newPosition;
        }
    }
}
