using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset; // Ba�lang��ta nesneye t�klad���n�z konumu saklayacak de�i�ken.
    private bool isDragging = false; // Nesneyi s�r�kleyip s�r�klememe durumunu belirleyecek de�i�ken.

    void OnMouseDown()
    {
        // Nesneye t�klad���n�zda ba�lang�� konumunu kaydedin ve s�r�kleme i�lemini ba�lat�n.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Fare d��mesini b�rakt���n�zda s�r�kleme i�lemini durdurun.
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Fare pozisyonunu d�nya koordinatlar�na d�n��t�r�n ve nesneyi ta��y�n.
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = transform.position.z; // Nesnenin z konumunu sabit tutmak i�in.

            // Nesneyi yeni konumuna ta��y�n.
            transform.position = newPosition;
        }
    }
}
