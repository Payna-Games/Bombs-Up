using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLeftRight : MonoBehaviour
{
    [SerializeField] private float swipeSpeed = 0.1f;
    [SerializeField] private float maxDistanceRight = 18f; // Sağ sınır
    [SerializeField] private float maxDistanceLeft = -18f; // Sol sınır
    public float bombSpeed = 5f;

    private Drop drop;
    [SerializeField] private float damping = 5f;
    private GameObject kilotonCanvas;
    [SerializeField] private bool downOpen;

    private float initialMouseX; // Mouse'un ilk X pozisyonu
    private float initialPositionX; // Bombanın ilk X pozisyonu

    private void Awake()
    {
        transform.parent.position = new Vector3(-1.81f, 5, 25.3f);
        kilotonCanvas = transform.GetChild(6).gameObject;
    }

    private void Start()
    {
        drop = GetComponent<Drop>();
        swipeSpeed = 0.2f;
        bombSpeed = 35f;
    }

    private void Update()
    {
        if (drop.rotateComplete)
        {
            // Bombanın dikey hareketi
            Vector3 move = new Vector3(0, bombSpeed * Time.deltaTime, 0);
            transform.Translate(move);

            // Mouse sol tuşa basılıysa
            if (Input.GetMouseButton(0)) 
            {
                // Mouse'un ilk pozisyonunu kaydet
                if (initialMouseX == 0)
                {
                    initialMouseX = Input.mousePosition.x;
                    initialPositionX = transform.position.x;
                }

                // Mouse hareketine göre delta hesapla
                float deltaX = (Input.mousePosition.x - initialMouseX) * swipeSpeed;

                // Yeni X pozisyonunu hesapla
                float targetX = initialPositionX + deltaX;
                
                // X pozisyonunu sınırla (hem sağ hem sol sınır)
                targetX = Mathf.Clamp(targetX, maxDistanceLeft, maxDistanceRight);

                // Yumuşak hareket için SmoothMove kullanımı
                SmoothMove(targetX);
            }
        }

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

    private void SmoothMove(float targetX)
    {
        // Mevcut konumu alın
        Vector3 currentPosition = transform.position;

        // Damping uygulayarak hedef konuma doğru yumuşak bir şekilde hareket ettirin
        Vector3 smoothedPosition = Vector3.Lerp(currentPosition, new Vector3(targetX, currentPosition.y, currentPosition.z), Time.deltaTime * damping);

        // Yeni konumu ayarlayın
        transform.position = smoothedPosition;
    }
}
