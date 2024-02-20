using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public int ammo = 10;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public void TakeDamage(int damage)
{
    health -= damage;

    if (health <= 0)
    {
        EnemyAI enemyAI = GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            
        }
    }
}

    void Shoot()
    {
        if (ammo > 0)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            ammo--;
        }
    }

    void Die()
    {
        // Implement death behavior here, such as playing a death animation or destroying the GameObject
        Destroy(gameObject);
    }
}
