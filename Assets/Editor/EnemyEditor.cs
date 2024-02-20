using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draw the default inspector

        Enemy enemyScript = (Enemy)target;

        // Add a button to apply damage
        if (GUILayout.Button("Apply 10 Damage"))
        {
            // Apply 10 damage to the enemy
            enemyScript.TakeDamage(10, Vector3.zero); // Assuming no knockback
        }
    }
}
