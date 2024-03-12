using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerAction))]
public class TriggerActionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draws the default inspector

        TriggerAction script = (TriggerAction)target;

        if (GUILayout.Button("Trigger Action"))
        {
            script.TriggerActionMethod();
        }
    }
}
