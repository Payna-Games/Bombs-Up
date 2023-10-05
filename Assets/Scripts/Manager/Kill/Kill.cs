using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    public Transform bomp;
    private string targetTag = "City";
    private GameObject[] cityObjects;

    void Awake()
    {
        bomp.GetComponent<BompExplode>().explodeCount += KillCount;
    }

    private void KillCount(int objCount)
    {
        cityObjects = GameObject.FindGameObjectsWithTag(targetTag);
        float fillAmount = ((float)objCount / 109.0f) * 10.0f;              //(float)cityObjects.Length) * 10.0f;
        //transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = objCount.ToString() + " / " + 109.ToString();
        transform.GetComponent<Image>().fillAmount = Mathf.Lerp(0, fillAmount, 0.1f);

        ////// burasý baþka bir alana taþýnacak
        MoneyManager.moneyManager.InreaseTotalMoney((float)750);
    }
}
