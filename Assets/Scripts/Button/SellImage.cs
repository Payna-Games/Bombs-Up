using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellImage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Sell.sell.mouseUp = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Sell.sell.mouseUp = false;
    }
}
