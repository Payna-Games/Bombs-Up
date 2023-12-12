//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class MoneyButtonAnim : MonoBehaviour
//{
//    public static MoneyButtonAnim moneyButtonAnim;
//    [SerializeField] private RectTransform moneyButtonTrans;
//    private void Awake()
//    {
//        moneyButtonAnim = moneyButtonAnim == null ? this : moneyButtonAnim;
//    }
//    private void Start()
//    {
//        moneyButtonTrans = GetComponent<RectTransform>();
//        //moneyButtonTrans.localPosition = new Vector3(15, -1100, 0.18f);
//    }
//    public void MoneyButAnim()
//    {
       
        
//        moneyButtonTrans.DOMove(new Vector3(15,180,0.18f),0.6f).SetEase(Ease.OutBounce);
//        //OnComplete(() =>
//        // {
//        //
//        //     panelObjects[2].transform.DOScale(new Vector3(1f, 1f, 1f), 0.7f);
//        // });


//    }
//}
