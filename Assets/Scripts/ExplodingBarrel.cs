using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    public int damage = 50;
    public int blastRange = 5;
    public int barrelHealth = 85;
    public Transform player;
    public PlayerHealth playerHealth;
    public GameObject particleSystemPrefab1; 
    public GameObject particleSystemPrefab2; 

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {

    }

    void Explode()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= blastRange)
        {
            playerHealth.TakeDamage(damage);
        }

        
        GameObject particles1 = Instantiate(particleSystemPrefab1, transform.position, Quaternion.identity);
        ParticleSystem particleSystem1 = particles1.GetComponent<ParticleSystem>();
        particleSystem1.Play();

        
        GameObject particles2 = Instantiate(particleSystemPrefab2, transform.position, Quaternion.identity);
        ParticleSystem particleSystem2 = particles2.GetComponent<ParticleSystem>();
        particleSystem2.Play();

        
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        barrelHealth -= damageAmount;
        if (barrelHealth <= 0)
        {
            Explode();
        }
    }

    
}
