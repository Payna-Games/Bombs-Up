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
        {
            GetComponent<TextMeshProUGUI>().text = "Tutorial";
            if (!PlayerPrefs.HasKey(transform.name))
            {
                PlayerPrefs.SetInt(transform.name, SceneManager.GetActiveScene().buildIndex);
            }
            else
                SceneManager.LoadScene(PlayerPrefs.GetInt(transform.name));
        }

        else
        {
            string[] parts = SceneManager.GetActiveScene().name.Split('-');
            GetComponent<TextMeshProUGUI>().text = "Lvl " + parts[1];
            PlayerPrefs.SetInt(transform.name, SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
