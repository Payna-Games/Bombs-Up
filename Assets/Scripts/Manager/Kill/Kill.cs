using TMPro;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public Transform bomp;
    private string targetTag = "City";
    private GameObject[] cityObjects;

    void Start()
    {
        cityObjects = GameObject.FindGameObjectsWithTag(targetTag);

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "0 / " + cityObjects.Length.ToString();
        bomp.GetComponent<BompExplode>().explodeCount += KillCount;
    }

    private void KillCount(int objCount)
    {
        cityObjects = GameObject.FindGameObjectsWithTag(targetTag);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = objCount.ToString() + " / " + cityObjects.Length.ToString();
    }
}
