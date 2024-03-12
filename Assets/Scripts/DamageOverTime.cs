using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public int damagePerSecond = 25; // Set this to the amount of damage per second you want to deal.

    private XRRigController xrRigController;

    private void Start()
    {
        // Find the XRRigController in the scene.
        xrRigController = FindObjectOfType<XRRigController>();
        if (xrRigController == null)
        {
            Debug.LogError("XRRigController not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Start damage over time when the player enters the gas area.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the gas area.");
            StartCoroutine(ApplyDamageOverTime(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop damage over time when the player exits the gas area.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited the gas area.");
            StopAllCoroutines(); // It's safe to call this if this script only runs this one coroutine. Otherwise, you should stop the coroutine more selectively.
        }
    }

    private IEnumerator ApplyDamageOverTime(Collider player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController script not found on player object. Damage Over Time cannot be applied.");
            yield break; // Exit the coroutine if the PlayerController component isn't found.
        }

        while (true)
        {
            // Check if the mask is equipped. If it is, do not apply damage.
            if (xrRigController != null && xrRigController.MaskEquipped)
            {
                Debug.Log("Player is wearing a mask, no damage will be applied.");
            }
            else
            {
                // Apply 25 damage if the player does not have the mask equipped.
                playerController.TakeDamage(damagePerSecond);
                Debug.Log($"Player took {damagePerSecond} damage from gas. Player health: {playerController.playerHealth}");
            }
            // Wait for one second before applying damage again.
            yield return new WaitForSeconds(1);
        }
    }
}