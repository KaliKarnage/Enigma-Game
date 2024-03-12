using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorController : MonoBehaviour
{
    public GameObject doorLeft; // Assign the left door part in the inspector
    public GameObject doorRight; // Assign the right door part in the inspector

    public float openSpeed = 3.0f; // Speed at which the doors open
    public float openDistance = 2.0f; // Distance each door moves when opening

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;
    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;

    private bool isOpening = false;

    void Start()
    {
        // Store the initial positions of the doors
        leftClosedPosition = doorLeft.transform.position;
        rightClosedPosition = doorRight.transform.position;

        // Calculate the open positions based on the openDistance
        leftOpenPosition = new Vector3(leftClosedPosition.x - openDistance, leftClosedPosition.y, leftClosedPosition.z);
        rightOpenPosition = new Vector3(rightClosedPosition.x + openDistance, rightClosedPosition.y, rightClosedPosition.z);
    }

    void Update()
    {
        // If the doors are opening, move them to their open positions
        if (isOpening)
        {
            doorLeft.transform.position = Vector3.MoveTowards(doorLeft.transform.position, leftOpenPosition, openSpeed * Time.deltaTime);
            doorRight.transform.position = Vector3.MoveTowards(doorRight.transform.position, rightOpenPosition, openSpeed * Time.deltaTime);
        }
    }

    // This method is called when the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the collider has a tag "Player"
        {
            isOpening = true;
        }
    }

    // Optionally, close the doors when the player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = false;
            // Move the doors back to their closed positions
            doorLeft.transform.position = leftClosedPosition;
            doorRight.transform.position = rightClosedPosition;
        }
    }
}
