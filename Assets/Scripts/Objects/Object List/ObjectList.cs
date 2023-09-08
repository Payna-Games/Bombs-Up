using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static ObjectList objectList;

    public List<GameObject> head;
    public List<GameObject> body;
    public List<GameObject> motor;

    public GameObject DragObject;

    private void Awake()
    {
        objectList = objectList == null ? this : objectList;
    }
}
