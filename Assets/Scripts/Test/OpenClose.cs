using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    [SerializeField] GameObject openClose;
    public void Open()
    {
        if(openClose.activeSelf == false)
        {
            openClose.gameObject.SetActive(true);
        }

        else
        {
            openClose.gameObject.SetActive(false);
        }
        
    }
}
