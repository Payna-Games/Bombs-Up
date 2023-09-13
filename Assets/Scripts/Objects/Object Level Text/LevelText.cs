using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    private ObjectLevel objectLevelScript;
    private TextMeshPro textMeshPro;

    private void OnEnable()
    {
        objectLevelScript = transform.parent.GetComponent<ObjectLevel>();
        textMeshPro = transform.GetComponent<TextMeshPro>();

        objectLevelScript.OnLevelUp += ObjLevelText;
    }
    private void OnDisable()
    {
        objectLevelScript.OnLevelUp -= ObjLevelText;
    }
    private void ObjLevelText(int level)
    {
        level += 1;
        textMeshPro.text = "Lvl " + level.ToString();
    }
}
