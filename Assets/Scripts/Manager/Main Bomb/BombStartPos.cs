using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YsoCorp.GameUtils;

public class BombStartPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if (YCManager.instance.abTestingManager.IsPlayerSample("new"))
        //{
            transform.position = new Vector3(0.7f, 6.4f, 23.4f);
            if (SceneManager.GetActiveScene().name == "Level-1-Tutorial")
            {
                transform.position = new Vector3(2.7f, 6.4f, 23.4f);
            }
        //}

        //else if (YCManager.instance.abTestingManager.IsPlayerSample("old"))
        //{
          
        //}
        //else { }
    }
}
