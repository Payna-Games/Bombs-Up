using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Drop : MonoBehaviour
{
    public float rotationDuration = 2f; // Dönme süresi (örneðin, 2 saniye)

    public GameObject arrow;    
    private Rigidbody rb;


    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false; // Use Gravity özelliðini devre dýþý býrak
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void DropBomb()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        Vector3 targetPosition = transform.position + Vector3.up * 5f;
        transform.DOMove(targetPosition, .5f).OnComplete(() =>
        {
            transform.DORotate(new Vector3(0f, 0f, 180f), rotationDuration)
                .OnComplete(() =>
                {
                    //CinemachineVirtualCamera camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
                    //camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(-2, 35, -40);
                    arrow.SetActive(true);
                });
        });
    }
}
