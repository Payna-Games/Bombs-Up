using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class TutorialAddButton : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject mask;
    [SerializeField] private GameObject mobileMask;
    public GameObject incomeButton;
    [SerializeField] private RectTransform targetPosition;
    public float moveDuration = 1.0f;
    
    private Vector3 screenPosition;
    [SerializeField] private Camera uiCamera;
    private Tween moveTween;
    
    private void Start()
    {
        StartInitialMove();
        ClickCount.clickCount.GetComponent<Button>().interactable = false;
        
   
      
      //  Debug.Log(screenPosition + ":Screen Position");
 
    }
    
    private void Update()
    {
        // Access the click count from EnoughMoney component
        int clickCount = SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount;

        // When click count is less than or equal to 2 and condition is met
        if (clickCount <= 2 )
        {
            incomeButton.GetComponent<EnoughMoney>().CanInteract = false;
            
        }
        else if (clickCount > 2)
        {
            mask.SetActive(false);
            StopHandAnimation();
        }
    }
    private void StartHandAnimation(Vector3 upPositionn)
    {
        // Aşağı pozisyon
        Vector3 upPosition = new Vector3(upPositionn.x, upPositionn.y +5f,upPositionn.z);

        // Yukarı-aşağı animasyonu başlat
        moveTween= rectTransform.DOMove(upPosition, moveDuration)
            .SetLoops(-1, LoopType.Yoyo) // Sonsuz döngüde git-gel
            .SetEase(Ease.Linear);
    } 
    private void StartInitialMove()
    {
        
        Vector3 downPosition = new Vector3(targetPosition.position.x, targetPosition.position.y+10f , targetPosition.position.z);
       // mask.transform.position =  new Vector3(targetPosition.position.x, targetPosition.position.y+7f , targetPosition.position.z);
        mask.SetActive(true);
        
        rectTransform.DOMove(downPosition, moveDuration)
            .OnComplete(() => StartHandAnimation(downPosition));
    }
    private void StopHandAnimation()
    {
        if (moveTween != null)
        {
            moveTween.Kill(); // Animasyonu durdur
        }
    }
   
}
