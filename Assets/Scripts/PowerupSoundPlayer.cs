using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the player.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            float sizeFactor = other.transform.localScale.magnitude;
            float pitch = 1.0f / sizeFactor;
            pitch = Mathf.Clamp(pitch, 0.5f, 1.5f);
            audioSource.pitch = pitch;
            audioSource.Play();
            Debug.Log("Collided with Powerup. Playing sound with pitch: " + pitch);
        }
    }
}


