using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManagement : MonoBehaviour
{
    public static LoopManagement Loop;
    public int loop;
    private void Awake()
    { 
        DontDestroyOnLoad(this);
        if (Loop == null)
        {
            Loop = this;
        }
        else
        {
            Destroy(gameObject);

        }
        
    }
   

   
}
