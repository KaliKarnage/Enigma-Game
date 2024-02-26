using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    private Collider triggerRadius;
    private AudioSource triggerSound;
    private AudioSource explosionSound;
    // Assuming you have a PlayerController script that handles player health
    // public PlayerController player;

    public int damage = 20;
    public ParticleSystem explosionEffect; 

    // Start is called before the first frame update
    void Start()
    {
        triggerRadius = GetComponent<SphereCollider>(); 
        
        AudioSource[] audioSources = GetComponents<AudioSource>();
        triggerSound = audioSources[0];
        explosionSound = audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerSound.Play(); 
            StartCoroutine(DelayedAction(2));
        }
    }

    public void Detonate()
    {
        if (explosionEffect != null)
        {
            explosionEffect.Play(); // Play the explosion particle system
        }
        explosionSound.Play(); // Play explosion sound

        // Apply damage to the player if within 3 meters (This part needs your own implementation based on your game's logic)
        // For example:
        // if (Vector3.Distance(player.transform.position, transform.position) <= 3f)
        // {
        //     player.TakeDamage(damage);
        // }

        Destroy(gameObject); // Destroy the landmine object
    }

    IEnumerator DelayedAction(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        Detonate();
    }
}
