using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TutorialAddButton : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 targetPosition2;
    public float moveDuration = 1.0f;
    public bool conditionMet = true;

    private void Start()
    {
        conditionMet = true;
        Transform addBottonPos = SlotAddButton.slotAddButton.transform;
        targetPosition = new Vector3(4, 4,-5);
        targetPosition2 = new Vector3(4, 4, -6f);
    }
    private void Update()
    {

        if (SlotAddButton.slotAddButton.transform.GetComponent<EnoughMoney>().clickCount <= 2 && conditionMet)
        {
            conditionMet = false;
            transform.DOMove(targetPosition, moveDuration)
                .OnComplete(() => transform.DOMove(targetPosition2, moveDuration)
                .OnComplete(()=>conditionMet = true ));            
        }
    }
}
