using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public BatterySlot batterySlot1; // Assign this in the Inspector
    public BatterySlot batterySlot2; // Assign this in the Inspector
    public GameObject doorLeft;
    public GameObject doorRight;

    public float openSpeed = 3f; // Speed at which the door opens
    public float openDistance = 3f; // Distance each door piece moves to open

    public bool isOpening = false;
    private Vector3 doorLeftClosedPosition;
    private Vector3 doorRightClosedPosition;
    private Vector3 doorLeftOpenPosition;
    private Vector3 doorRightOpenPosition;

    private AudioSource audioSource;
    

    private void Start()
    {
        // Initialize door positions
        doorLeftClosedPosition = doorLeft.transform.localPosition;
        doorRightClosedPosition = doorRight.transform.localPosition;
        // Calculate open positions based on the open distance along the local Z axis
        doorLeftOpenPosition = doorLeftClosedPosition + new Vector3(0, 0, -openDistance);
        doorRightOpenPosition = doorRightClosedPosition + new Vector3(0, 0, openDistance);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check if both battery slots are charged and the door is not already opening
        if (batterySlot1.IsCharged && batterySlot2.IsCharged && !isOpening)
        {
            
            if (!audioSource.isPlaying )
            {
                audioSource.Play();
            }

            StartCoroutine(DelayedAction(5));
        }

        // If the door is opening, move each piece along its local Z-axis
        if (isOpening)
        {
            doorLeft.transform.localPosition = Vector3.MoveTowards(doorLeft.transform.localPosition, doorLeftOpenPosition, openSpeed * Time.deltaTime);
            doorRight.transform.localPosition = Vector3.MoveTowards(doorRight.transform.localPosition, doorRightOpenPosition, openSpeed * Time.deltaTime);

            // Optionally, you can add a condition to check if the doors are fully opened and then perform any necessary actions, like stopping further updates.
            if (doorLeft.transform.localPosition == doorLeftOpenPosition && doorRight.transform.localPosition == doorRightOpenPosition)
            {
                // Doors are fully opened. Perform any actions needed when doors are fully open.
                isOpening = false; // This could be used to stop further updates or trigger other actions.

                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }

        }
    }

    IEnumerator DelayedAction(float delayInSeconds)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delayInSeconds);

        // Code after the delay
        Debug.Log("This message is shown after a 5 seconds delay.");
        isOpening = true;
    }
}
