using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Billboard : MonoBehaviour
{
    private XRRig xrRig;
    private Camera uiCamera;

    private void Start()
    {
        // Find the XRRig in the scene
        xrRig = FindObjectOfType<XRRig>();
        // Assign the camera from the XRRig to uiCamera
        if (xrRig != null)
        {
            uiCamera = xrRig.cameraGameObject.GetComponent<Camera>();
        }
    }

    private void Update()
    {
        if (uiCamera != null)
        {
            // Billboard the canvas by making it face the opposite direction of the camera's forward vector
            transform.forward = uiCamera.transform.forward * -1;
        }
    }
}
