using TMPro;
using UnityEngine;

public class KTonText : MonoBehaviour
{
    private void Start()
    {
        KiloTonCalculate.kiloTonCalculate.kTon += KTonText_kTon;
    }

    private void KTonText_kTon(int kTon)
    {
        GetComponent<TextMeshProUGUI>().text = kTon.ToString();
    }
}
