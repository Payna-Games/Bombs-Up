using UnityEngine;
using System;
using DG.Tweening;
using Cinemachine;
using System.Collections.Generic;
using System.Collections;
using YsoCorp.GameUtils;

public class Drop : MonoBehaviour
{
    public float rotationDuration = 2f; // D�nme s�resi (�rne�in, 2 saniye)

    public event Action windPlay;

    public GameObject swipeMove;

    public List<GameObject> Lens;

    private Rigidbody rb;
    private CinemachineVirtualCamera camera;
    public float bombSpeed;
    public bool rotateComplete = false;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false; // Use Gravity �zelli�ini devre d��� b�rak
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        rotateComplete = false;
    }

    public void DropBomb()
    {
        rb.constraints = RigidbodyConstraints.None;
        //rb.useGravity = true;
        if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        {
            Vector3 targetPosition = transform.position + Vector3.up * 5f;
            transform.DOMove(targetPosition, 2f).OnComplete(() =>
            {
                transform.DOMove(new Vector3(-3, 6.4f, 23.4f), rotationDuration);
                transform.DORotate(new Vector3(0f, 0f, -180f), rotationDuration).OnComplete(() =>
                {
                    LensActive();

                    camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
                    StartCoroutine(MoveCamera());



                });
            });
        }
        else if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        {
            transform.DOMove(new Vector3(-3, 6.4f, 23.4f), rotationDuration);
            transform.DORotate(new Vector3(0f, 0f, -180f), rotationDuration).OnComplete(() =>
            {
                LensActive();

                camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
                StartCoroutine(MoveCamera());
            });
        }
        else
        {
            transform.DOMove(new Vector3(-3, 6.4f, 23.4f), rotationDuration);
            transform.DORotate(new Vector3(0f, 0f, -180f), rotationDuration).OnComplete(() =>
            {
                LensActive();

                camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
                StartCoroutine(MoveCamera());
            });
        }
    }

    private void LensActive()
    {
        for (int i = 0; i < Lens.Count; i++)
        {
            Lens[i].SetActive(true);
        }
    }

    private IEnumerator MoveCamera()
    {
        swipeMove.SetActive(false);
        Debug.Log("kamera başlangıç");
        for (int i = 0; i < 1; i++)
        {
            camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset += new Vector3(0, 0.08f, 0.042f);

            yield return new WaitForSeconds(0.01f);

        }

        swipeMove.SetActive(true);
        windPlay?.Invoke();
        rotateComplete = true;
    }


}
