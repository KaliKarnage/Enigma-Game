using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damageAmount = 20f; // Set the damage amount
    public float knockbackForce = 10f; // Set the knockback force

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Check if collided object is an enemy
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>(); // Access Enemy script

            if (enemy != null)
            {
                Vector3 direction = collision.transform.position - transform.position; // Calculate direction
                direction = direction.normalized; // Normalize direction
                enemy.TakeDamage((int)damageAmount, direction * knockbackForce); // Call TakeDamage() function
            }
        }
    }
}
