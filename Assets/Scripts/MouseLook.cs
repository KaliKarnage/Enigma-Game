using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 10f;

    private float xRotation = 0f;
    private Vector2 currentMouseDelta;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        currentMouseDelta = Mouse.current.delta.ReadValue();
    }

    void LateUpdate()
    {
        Vector2 mouseDelta = currentMouseDelta * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player body around the Y-axis and lock Z-axis rotation
        playerBody.rotation = Quaternion.Euler(playerBody.rotation.eulerAngles.x, playerBody.rotation.eulerAngles.y + mouseDelta.x, 0f);
    }
}
