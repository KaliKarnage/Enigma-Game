using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Rigidbody rb;
    [SerializeField] private GameObject damageNumberPrefab;
    public int enemyLevel = 1;
    public enum EnemyType { Normal, Champion, Elite, Boss }
    public EnemyType type = EnemyType.Normal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, 100);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount, Vector3 knockbackForce)
{
    // Assuming 'rb' is a Rigidbody component
    if (rb != null)
    {
        rb.AddForce(knockbackForce, ForceMode.Impulse);
    }
    else
    {
        Debug.LogError("Rigidbody component is missing or not assigned.");
    }

    // Show floating damage number
    GameObject damageNumbers = Instantiate(damageNumberPrefab, transform.position, Quaternion.identity);
    
    // Ensure the DamageNumber script is attached to the prefab
    DamageNumber damageNumberScript = damageNumbers.GetComponent<DamageNumber>();
    if(damageNumberScript != null)
    {
        // Call SetDamage which should update the TextMeshPro component within the DamageNumber script
        damageNumberScript.SetDamage(damageAmount);
    }
    else
    {
        Debug.LogError("DamageNumber script is not found on the instantiated damageNumberPrefab");
    }

    // Subtract the damage from the enemy's health
    Health -= damageAmount;
}




}
