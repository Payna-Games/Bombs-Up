using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public Transform mainBomp;

    private void Start()
    {

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.tag == transform.parent.GetChild(i).transform.tag)
            {
                SetFalse();
                SetTrue(mainBomp.GetChild(i).GetComponent<ObjectLevel>().objectLevel);
                mainBomp.GetChild(i).GetComponent<ObjectLevel>().otherBomp += ChangeObj;
            }
        }
    }
    private void ChangeObj(int i)
    {
        SetFalse();
        SetTrue(mainBomp.GetChild(i).GetComponent<ObjectLevel>().damageLevel);
    }
    public void SetFalse()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            if (child != transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void SetTrue(int objectLevel)
    {
        transform.GetChild(objectLevel).gameObject.SetActive(true);
    }
}
