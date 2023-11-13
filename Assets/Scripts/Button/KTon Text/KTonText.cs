using System;
using TMPro;
using UnityEngine;

public class KTonText : MonoBehaviour
{
    public FollwChange follwChange;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        KiloTonCalculate.kiloTonCalculate.kTon += KTonText_kTon;
        // follwChange.changeCamera += SetFalse;
    }

    

    

    private void KTonText_kTon(int kTon)
    {
        //GetComponent<TextMeshProUGUI>().text = kTon.ToString();
        text.text = kTon.ToString();
    }
    private void SetFalse()
    {
        transform.parent.gameObject.SetActive(false);
    }
}