using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialAddButton : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject mask;
    public GameObject incomeButton;
    [SerializeField] private RectTransform targetPosition;
    private RectTransform targetPosition2; 
    public float moveDuration = 1.0f;
    public bool conditionMet = true;
    private Vector3 screenPosition;
    [SerializeField] private Camera uiCamera; 
    private void Start()
    {
        conditionMet = true;
        ClickCount.clickCount.GetComponent<Button>().interactable = false;
        
        Transform addBottonPos = SlotAddButton.slotAddButton.transform;
      
        Debug.Log(screenPosition + ":Screen Position");
       
    }
    
    private void Update()
    {
        // Access the click count from EnoughMoney component
        int clickCount = SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount;

        // When click count is less than or equal to 2 and condition is met
        if (clickCount <= 2 && conditionMet)
        {
            incomeButton.GetComponent<EnoughMoney>().CanInteract = false;
            conditionMet = false;
            mask.SetActive(true);

          
            rectTransform.DOMove(targetPosition.position, moveDuration)
                .OnComplete(() => 
                {
                 
                    Vector3 targetPosition2 = new Vector3(targetPosition.position.x, targetPosition.position.y + 10f, targetPosition.position.z);
                    rectTransform.DOMove(targetPosition2, moveDuration)
                        .OnComplete(() => conditionMet = true);
                });
        }
        else if (clickCount > 2)
        {
            mask.SetActive(false);
        }
    }


}
