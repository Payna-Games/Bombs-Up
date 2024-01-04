using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YsoCorp.GameUtils;

public class BombVersion : MonoBehaviour
{
    private void Awake()
    {
        
         if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
         {

         }
        else
        {
            transform.parent.position = new Vector3(-1.81f, 5, 25.3f);      // parent objenin pos ayarı,
            transform.parent.rotation = Quaternion.Euler(0, 0, 0);  // parent objenin pos ayarı,

            transform.localPosition = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(-20, 180, 0);

            transform.GetChild(0).GetComponent<BoxCollider>().center = new Vector3(-0.6757f, 1.9f, 2.273f);
            transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(2.0821f, 0.575f, 5.557f);

            transform.GetChild(1).GetComponent<BoxCollider>().center = new Vector3(-0.529f, 0.212f, 2.8976f);
            transform.GetChild(1).GetComponent<BoxCollider>().size = new Vector3(2.059f, 2.2535f, 4.1612f);

            transform.GetChild(2).GetComponent<BoxCollider>().center = new Vector3(0.66f, -0.9435f, 2.592f);
            transform.GetChild(2).GetComponent<BoxCollider>().size = new Vector3(2.564f, 0.6688f, 6.124f);

            transform.GetChild(6).GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.56f, -4.9f, 0.3f);
            transform.GetChild(6).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180, 0);

            transform.GetChild(0).GetChild(8).localPosition = new Vector3(1.015f, 1.34f, 0.1f);
            transform.GetChild(0).GetChild(8).localRotation = Quaternion.Euler(8, 180, 0);
            transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, -0.07f);
            transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);

            transform.GetChild(1).GetChild(8).localPosition = new Vector3(-2.3f, 0, 0);
            transform.GetChild(1).GetChild(8).localRotation = Quaternion.Euler(8, 0, 0);
            transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-1.104f, 0.07f, 0.136f);
            transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<RectTransform>().localRotation = Quaternion.Euler(8, 180, 0);

            transform.GetChild(2).GetChild(8).localPosition = new Vector3(0.91f, -2.33f, 0);
            transform.GetChild(2).GetChild(8).localRotation = Quaternion.Euler(8, 180, 0);
            transform.GetChild(2).GetChild(8).GetChild(0).GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, -0.05f);
            transform.GetChild(2).GetChild(8).GetChild(0).GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
