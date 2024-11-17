using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombLeftRight : MonoBehaviour
{
    [SerializeField] private float swipeSpeed = 0.1f;
    [SerializeField] private float maxDistanceRight;
    public float bombSpeed = 5f;

    [SerializeField] private float damping = 5f;
    private GameObject kilotonCanvas;
    [SerializeField] private bool downOpen;
    private Drop drop;
    private void Awake()
    {
        transform.parent.position = new Vector3(-1.81f, 5, 25.3f);
        kilotonCanvas = transform.GetChild(6).gameObject;
    }

    private void Start()
    {
        
           
        

        swipeSpeed = 0.2f;
        bombSpeed = 35f;
        drop = GetComponent<Drop>();
    }

private void Update()
{
    if (drop.rotateComplete) {
        Vector3 move = new Vector3(0, bombSpeed * Time.deltaTime, 0);
        transform.Translate(move);

        if (Input.GetMouseButton(0)) { // Fare tıklanmışsa
            Vector3 mousePosition = Input.mousePosition; // Fare pozisyonu alın
            Debug.Log($"Mouse Position: {mousePosition.x}");

            // Fare pozisyonunu ekranın genişliğine göre normalize et
            float normalizedX = mousePosition.x / Screen.width;

            // Ekranın sağ ve sol sınırlarını 18 ve -18 arasında bir aralığa yerleştir
            // Eğer fare sağa kayarsa bomba sağa, sola kayarsa sola gitmeli
            float targetX = Mathf.Lerp(18, -18, normalizedX); // Bu şekilde yön düzeltildi

            // Damping uygulayarak hedef konuma hareket ettirin
            SmoothMove(targetX);
        }
    }

    // Bomba bitiş kısmı kontrolü
    if (LastLensAfter.lastLensAfter.lastLensPassed)
    {
        Transform parentTransform = transform.parent;
        kilotonCanvas.SetActive(false);
        swipeSpeed = 0f;
        parentTransform.position = new Vector3(0, 0, 0);
        transform.position = new Vector3(0, transform.position.y, 0);

        if (downOpen)
        {
            bombSpeed = 80f;
        }
        else if (!downOpen)
        {
            bombSpeed = 0f;
        }
        MiniBompManager.miniBompManager.spawnSpeed = 0;
    }
}

// SmoothMove fonksiyonu, yumuşak hareket sağlamak için
private void SmoothMove(float targetX)
{
    // Mevcut konumu al
    Vector3 currentPosition = transform.position;

    // Hedef pozisyona doğru yumuşak hareket uygulayalım
    Vector3 smoothedPosition = Vector3.Lerp(currentPosition, new Vector3(targetX, currentPosition.y, currentPosition.z), Time.deltaTime * damping);
    Debug.Log("mouse hareket etmesi gerek");

    // Yeni pozisyonu ayarla
    transform.position = smoothedPosition;
}


}
