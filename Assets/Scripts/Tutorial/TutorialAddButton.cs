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
    [SerializeField] private RectTransform targetPosition2; 
    public float moveDuration = 1.0f;
    public bool conditionMet = true;

    private void Start()
    {
        conditionMet = true;
        ClickCount.clickCount.GetComponent<Button>().interactable = false;
        
        Transform addBottonPos = SlotAddButton.slotAddButton.transform;
        
        
    }
    private void Update()
    {

        if (SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount <= 2 && conditionMet)
        {
            incomeButton.GetComponent<EnoughMoney>().CanInteract = false;
            conditionMet = false;
            mask.SetActive(true);
            rectTransform.DOAnchorPos(targetPosition.anchoredPosition, moveDuration)
                .OnComplete(() => rectTransform.DOAnchorPos(targetPosition2.anchoredPosition, moveDuration)
                .OnComplete(()=>conditionMet = true ));            
        }
        else if (SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount > 2)// && !conditionMet)
        {
            mask.SetActive(false);
        }
    }
}
