using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollwChange : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Sanal kamera referansý
    public Transform newFollowTarget; // Yeni takip hedefi

    void Start()
    {
        //newFollowTarget = GameObject.Find("City").transform;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ChangeFollow()
    {
        //virtualCamera.Follow = newFollowTarget;
    }
}
