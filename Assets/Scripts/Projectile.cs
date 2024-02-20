using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damageAmount = 25;
    public float destroyAfterSeconds = 5f;
    public float speed = 100f;
    public float knockbackForce = 5f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            Debug.LogError("Projectile does not have a Rigidbody component.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Vector3 direction = collision.transform.position - transform.position; // Calculate direction
                direction = direction.normalized; // Normalize direction
                enemy.TakeDamage(damageAmount, direction * knockbackForce); // add knockbackForce argument
            }
        }


        if (collision.gameObject.CompareTag("EnvironmentalHazard"))
        {
            // Perform any actions you want to happen when the bullet hits an enemy, such as applying damage
            // For example, if the enemy has a script called "EnemyHealth", you could call a method like this:
            // collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            collision.gameObject.GetComponent<ExplodingBarrel>().TakeDamage(damageAmount);
        }


        // Destroy the bullet upon collision
        Destroy(gameObject);
    }
}
