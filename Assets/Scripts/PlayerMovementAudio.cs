using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovementAudio : MonoBehaviour
{
    public XRBaseController leftController;
    public XRBaseController rightController;
    public AudioSource audioSource;
    private Vector2 lastInputVector;
    private bool isMoving = false;
    private float movementThreshold = 0.1f; // Threshold to determine if the player is moving

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastInputVector = Vector2.zero;
    }

    void Update()
    {
        // Replace GetInputVector with the correct method to get the input vector from your controllers
        Vector2 currentInputVector = GetInputVector();

        // Check if the player is moving by comparing the current input vector to the last frame's input vector
        if (currentInputVector != lastInputVector)
        {
            if (!audioSource.isPlaying)
            {
                // Randomly change the playback speed and volume
                audioSource.pitch = Random.Range(0.9f, 1.2f);
                audioSource.volume = Random.Range(0.4f, 1f);

                // Play the audio
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Update lastInputVector for the next frame
        lastInputVector = currentInputVector;
    }

    
    Vector2 GetInputVector()
    {
        
        return Vector2.zero;
    }
}



