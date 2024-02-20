using UnityEngine;

public class BatterySlot : MonoBehaviour
{
    // These GameObject references should be assigned in the Unity Inspector
    public GameObject emptyBatteryModel;
    public GameObject chargedBatteryModel;
    public bool IsCharged { get; private set; }
    private AudioSource audioSource;

    private void Start()
    {
        // Ensure that the charged model is inactive at the start
        chargedBatteryModel.SetActive(false);
        IsCharged = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Try to get the XRRigController from the player
        XRRigController xrRigController = other.GetComponent<XRRigController>();
        
        // If the XR Rig has a battery and the slot is not charged
        if (xrRigController != null && xrRigController.BatteryCount > 0 && !IsCharged)
        {
            ChargeBattery();
            xrRigController.UseBattery(); // Decrement the player's battery count
        }
    }

    // This public method can be called by the editor script to charge the battery
    public void ChargeBattery()
    {
        // Only charge if the slot isn't already charged
        if (!IsCharged)
        {
            // Deactivate the empty model and activate the charged model
            if (emptyBatteryModel != null)
                emptyBatteryModel.SetActive(false);

            if (chargedBatteryModel != null)
                chargedBatteryModel.SetActive(true);

            IsCharged = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            Debug.Log("Battery slot charged.");
        }
    }

    // The rest of your collision handling and other methods can remain here
    // ...
}
