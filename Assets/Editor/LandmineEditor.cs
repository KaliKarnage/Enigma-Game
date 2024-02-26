using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Landmine))]
public class LandmineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        Landmine landmineScript = (Landmine)target;

        if (GUILayout.Button("Detonate Mine"))
        {
            landmineScript.Detonate();
        }
    }
}