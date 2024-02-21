using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the GameObject.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object triggering this is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("Player has triggered the sound.");
            }
        }
    }
}
