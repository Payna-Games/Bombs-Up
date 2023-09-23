using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    private ObjectLevel objectLevelScript;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        objectLevelScript = transform.parent.parent.GetComponent<ObjectLevel>();
        objectLevelScript.OnLevelUp += ObjLevelText;

        textMeshPro = transform.GetComponent<TextMeshPro>();
    }
    private void ObjLevelText(int level)
    {
        level += 1;
        textMeshPro.text = level.ToString();
    }
}
