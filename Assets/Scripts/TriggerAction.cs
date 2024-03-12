using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    // Assign the GameObject you want to destroy in the Inspector
    public GameObject objectToDestroy;

    // Optional: Name of the animation trigger
    public string animationTriggerName = "PlayAnimation";

    //private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to this GameObject
        /* animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        } */
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag 'Weapon'
        if (collision.gameObject.CompareTag("Weapon"))
        {
            // Trigger the animation
            /* if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
            } */

            // Optional: If you want to wait for the animation to finish, you can use a Coroutine
            // Otherwise, you can destroy the object immediately or after a delay
            Destroy(objectToDestroy, 0.5f); // Adjust the delay to match your animation length
        }
    }

    public void TriggerActionMethod()
    {
        // Your code here. For example:
        Debug.Log("Action triggered via the Inspector button.");
        Destroy(objectToDestroy, 0.5f);
    }
}

