using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OVR;

public class VRCharacterController : MonoBehaviour
{
    public Transform xrRig;
    public Transform vrCamera;
    public float speed = 1.5f;
    public OVRInput.Controller controller;
    public OVRInput.Button moveButton;
    public OVRInput.Button jumpButton;

    private Vector3 moveDirection;

    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
        Move(input);
        xrRig.position += moveDirection * Time.deltaTime;

        if (OVRInput.GetDown(jumpButton, controller))
        {
            Jump();
        }
    }

    private void Move(Vector2 input)
    {
        Vector3 forward = vrCamera.forward;
        forward.y = 0; // This ensures that the character doesn't move upwards when looking up.
        forward.Normalize(); // Normalize the vector to ensure consistent speed in all directions.

        Vector3 right = vrCamera.right;
        right.y = 0; // This ensures that the character doesn't move upwards when looking up.
        right.Normalize(); // Normalize the vector to ensure consistent speed in all directions.

        moveDirection = (forward * input.y + right * input.x) * speed;
    }

    public void Jump()
    {
        Debug.Log("Jump triggered");
    }
}
