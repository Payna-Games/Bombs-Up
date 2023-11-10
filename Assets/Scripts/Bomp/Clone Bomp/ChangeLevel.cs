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
                if (mainBomp.GetChild(i).GetComponent<ObjectLevel>().objectLevel < mainBomp.GetChild(i).GetComponent<ObjectLevel>().damageLevel)
                    SetTrue(mainBomp.GetChild(i).GetComponent<ObjectLevel>().damageLevel);
                else
                    SetTrue(mainBomp.GetChild(i).GetComponent<ObjectLevel>().objectLevel);
                mainBomp.GetChild(i).GetComponent<ObjectLevel>().otherBomp += ChangeObj;
            }
        }
    }
    private void ChangeObj(int i)
    {
        int j = GetChildIndex();
        SetFalse();
        SetTrue(i);  // mainBomp.GetChild(j).GetChild(i).GetComponent<ObjectLevel>().damageLevel
    }
    int GetChildIndex()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i) == transform)
            {
                return i;
            }
        }
        return -1; // Child obje parent objenin altýndaysa bulunamazsa -1 döner.
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
