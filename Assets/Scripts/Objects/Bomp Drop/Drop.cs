using UnityEngine;
using DG.Tweening;

public class Drop : MonoBehaviour
{
    public float rotationDuration = 2f; // D�nme s�resi (�rne�in, 2 saniye)

    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false; // Use Gravity �zelli�ini devre d��� b�rak
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void DropBomb()
    {rb.constraints = RigidbodyConstraints.None;
                    rb.useGravity = true;
        Vector3 targetPosition = transform.position + Vector3.up * 5f;
        transform.DOMove(targetPosition, .5f).OnComplete(() =>
        {
            // D�nme animasyonunu ba�lat
            transform.DORotate(new Vector3(-20f, 0f, 180f), rotationDuration)
                .OnComplete(() =>
                {
                    
                });
        });
    }
}
