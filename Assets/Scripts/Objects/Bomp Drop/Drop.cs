using UnityEngine;
using System;
using DG.Tweening;
using Cinemachine;
using System.Collections.Generic;
using System.Collections;

public class Drop : MonoBehaviour
{
    public float rotationDuration = 2f; // D�nme s�resi (�rne�in, 2 saniye)

    public event Action windPlay;

    public List<GameObject> arrow;
    private Rigidbody rb;
    private CinemachineVirtualCamera camera;
    public float bombSpeed;
    public bool rotateComplete = false;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false; // Use Gravity �zelli�ini devre d��� b�rak
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void DropBomb()
    {
        rb.constraints = RigidbodyConstraints.None;
        //rb.useGravity = true;
        Vector3 targetPosition = transform.position + Vector3.up * 5f;
        transform.DOMove(targetPosition, 2f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(0f, 0f, -180f), rotationDuration).OnComplete(() =>
                {
                    windPlay?.Invoke();
                    foreach (GameObject item in arrow)
                        item.SetActive(true);
                    camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
                    StartCoroutine(MoveCamera());
                    rotateComplete = true;
                    
                });
        });
    }
    private IEnumerator MoveCamera()
    {
        for (int i = 0; i < 100; i++)
        {
            camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset += new Vector3(0, 0.08f, 0.042f);

            yield return new WaitForSeconds(0.01f);
            
        }
    }

    
}
