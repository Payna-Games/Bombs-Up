using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLeftRight : MonoBehaviour
{
    public float bombSpeed = 5f;

    private Drop drop;
    private GameObject kilotonCanvas;
    [SerializeField] private bool downOpen;

    private float initialPositionX; // Bombanın ilk X pozisyonu
    private float lastMouseX; // Son tıklanan mouse X pozisyonu

    [Header("Movement Limits")]
    [SerializeField] private float minX = -5f;  // Sol sınır
    [SerializeField] private float maxX = 5f;   // Sağ sınır

    [Header("Damping")]
    [SerializeField] private float damping = 10f;  // Damping değeri

    private Vector3 velocity = Vector3.zero; // Bombanın hızını kontrol etmek için kullanılan vektör

    private void Awake()
    {
        transform.parent.position = new Vector3(-1.81f, 5, 25.3f);
        kilotonCanvas = transform.GetChild(6).gameObject;
    }

    private void Start()
    {
        drop = GetComponent<Drop>();
        bombSpeed = 35f;
        initialPositionX = transform.position.x;  // Bomba başlangıç pozisyonu
    }

    private void Update()
    {
        if (drop.rotateComplete)
        {
            // Bombanın dikey hareketi
            Vector3 move = new Vector3(0, bombSpeed * Time.deltaTime, 0);
            transform.Translate(move);

            // Mouse hareketini izleme
            if (Input.GetMouseButton(0))  // Mouse'a tıklanırsa hareket etsin
            {
                // Mouse'un yatay pozisyonunu alıyoruz
                float mouseX = Input.mousePosition.x;

                // Ekranda tıklama olduğu anda son tıklanan pozisyonu kaydediyoruz
                if (lastMouseX == 0)
                {
                    lastMouseX = mouseX;
                }

                // Mouse'un yatay hareketini takip et (ters hareketi düzeltmek için işareti düzelt)
                float deltaX = lastMouseX - mouseX;

                // Bombayı X ekseninde kaydırıyoruz, deltaX'in çarpanını küçük yaparak kayma hızını yavaşlatıyoruz
                float targetX = transform.position.x + deltaX * 0.1f;

                // X pozisyonunu sınırlarla kısıtla
                targetX = Mathf.Clamp(targetX, minX, maxX);

                // Bombanın yeni pozisyonunu yumuşatarak ayarlıyoruz (Damping uygulandı)
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), ref velocity, damping * Time.deltaTime);
                
                // Son tıklanan pozisyonu güncelle
                lastMouseX = mouseX;
            }
            else
            {
                // Eğer mouse tıklaması bitmişse, tıklanan pozisyonu sıfırla
                lastMouseX = 0;
            }
        }

        if (LastLensAfter.lastLensAfter.lastLensPassed)
        {
            Transform parentTransform = transform.parent;
            kilotonCanvas.SetActive(false);
            bombSpeed = 0f;
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
}
