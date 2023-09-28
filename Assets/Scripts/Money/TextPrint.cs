using UnityEngine;
using TMPro;

public class TextPrint : MonoBehaviour
{
    public virtual void ButtonPrint(long amount)
    {
        if (amount >= 1000000000)
        {
            float money = (float)amount / 1000000000;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = money.ToString("F1") + " b";
        }
        else if (amount >= 1000000)
        {
            float money = (float)amount / 1000000;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = money.ToString("F1") + " m";
        }
        else if (amount >= 1000)
        {
            float money = (float)amount / 1000;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = money.ToString("F1") + " k";
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = amount.ToString();
        }
    }
}
