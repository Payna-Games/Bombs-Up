using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSetFalse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                KiloTonCalculate.kiloTonCalculate.gameObject.GetComponent<BombLeftRight>().bombSpeed = 35;
                gameObject.SetActive(false);
            }
        }
        else
        {
            KiloTonCalculate.kiloTonCalculate.gameObject.GetComponent<BombLeftRight>().bombSpeed = 15;
        }
    }
}
