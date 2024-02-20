using UnityEngine;

public class AssignEventCamera : MonoBehaviour
{
    private Canvas canvasComponent;

    void Awake()
    {
        // Get the Canvas component on this GameObject
        canvasComponent = GetComponent<Canvas>();

        // If the component is not found, log an error
        if (canvasComponent == null)
        {
            Debug.LogError("Canvas component not found on the GameObject", this);
        }
        else
        {
            // Find the camera tagged as "MainCamera" and set it as the event camera for the canvas
            canvasComponent.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            // Log an error if we didn't find a main camera
            if (canvasComponent.worldCamera == null)
            {
                Debug.LogError("MainCamera with Camera component not found in the scene", this);
            }
        }
    }
}
