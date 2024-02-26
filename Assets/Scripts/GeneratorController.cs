using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    // Public variables for the generator GameObjects
    public GameObject generator;
    public GameObject generatorDestroyed;

    // Public variables for the audio sources
    public AudioSource runningAudioSource;
    public AudioSource shutOffAudioSource;

    public GameObject forceField;

    // Health variable for the generator
    public int health = 75;

    // Boolean to check if the generator is already destroyed
    private bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the generator is active and the destroyed version is inactive at the start
        generator.SetActive(true);
        generatorDestroyed.SetActive(false);

        // Play the running sound if the generator is active
        if (runningAudioSource != null)
        {
            runningAudioSource.Play();
        }
    }

    private void Update() 
    {
       if (health <= 0)
            {
                DestroyGenerator();
            } 
    }

    // Call this method to apply damage to the generator
    public void TakeDamage(int damageAmount)
    {
        // Only take damage if the generator is not already destroyed
        if (!isDestroyed)
        {
            health -= damageAmount;
            if (health <= 0)
            {
                DestroyGenerator();
            }
        }
    }

    // Call this method to "destroy" the generator
    public void DestroyGenerator()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            generator.SetActive(false);
            generatorDestroyed.SetActive(true);
            if (runningAudioSource != null)
            {
                runningAudioSource.Stop();
            }
            if (shutOffAudioSource != null)
            {
                shutOffAudioSource.Play();
            }
            // Destroy the forcefield when the generator is destroyed
            if (forceField != null)
            {
                Destroy(forceField);
            }
        }
    }
}


