using UnityEngine;

public class Sell : MonoBehaviour
{    
    public void OnPointExit()
    {
        ObjectList.objectList.DragObject.GetComponent<ObjectLevel>().objectLevel = 0;
        ObjectList.objectList.DragObject.SetActive(false);
        ObjectList.objectList.DragObject.GetComponent<DragAndDrop>().PrevGridNull();
    }
}
