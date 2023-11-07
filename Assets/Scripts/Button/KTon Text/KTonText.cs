using TMPro;
using UnityEngine;

public class KTonText : MonoBehaviour
{
    public Transform bomp;
    private void Start()
    {
        bomp.GetComponent<KiloTonCalculate>().kTon += KTonText_kTon;
    }

    private void KTonText_kTon(int kTon)
    {
        GetComponent<TextMeshProUGUI>().text = "KTon " + kTon;
    }
}
