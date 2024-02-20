using UnityEngine;
using TMPro;

public class VRDebugConsole : MonoBehaviour
{
    public TMP_Text debugText;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Log)
        {
            debugText.text += logString + "\n";
        }
    }
}
