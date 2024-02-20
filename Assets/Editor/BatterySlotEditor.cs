using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BatterySlot))]
public class BatterySlotEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        // Cast the target to a BatterySlot
        BatterySlot slot = (BatterySlot)target;

        // If your button is pressed
        if (GUILayout.Button("Charge Battery"))
        {
            // Call your method to charge the battery
            slot.ChargeBattery();
        }
    }
}
