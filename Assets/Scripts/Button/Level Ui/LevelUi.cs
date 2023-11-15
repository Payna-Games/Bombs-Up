using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Tutorial"))
            GetComponent<TextMeshProUGUI>().text = "Tutorial";
        else
        {
            string[] parts = SceneManager.GetActiveScene().name.Split('-');
            GetComponent<TextMeshProUGUI>().text = "Lvl " + parts[1];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
