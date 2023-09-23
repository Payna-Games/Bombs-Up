using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObj : MonoBehaviour
{
    private void Start()
    {
        GameObject obj = transform.GetComponent<GridIsEmpty>().gridObject;
        if (obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<DragAndDrop>().prevGrid = gameObject;
            obj.transform.position = transform.position;
            if (PlayerPrefs.HasKey(obj.name))
            {
                obj.GetComponent<ObjectLevel>().ObjectActive(PlayerPrefs.GetInt(obj.name));
            }
        }

    }
}
