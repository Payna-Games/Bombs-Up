using UnityEngine;

public class Sell : MonoBehaviour
{    
    public void OnPointExit()
    {
        ObjectList.objectList.DragObject.SetActive(false);
        ObjectList.objectList.DragObject.GetComponent<DragAndDrop>().PrevGridNull();
    }
}
