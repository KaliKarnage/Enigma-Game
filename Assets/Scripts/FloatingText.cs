using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    Transform vrCamera;
    Transform unit;
    Transform worldSpaceCanvas;
    TextMeshProUGUI textComponent;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Find the OVR Camera Rig in the scene
        OVRCameraRig ovrCameraRig = FindObjectOfType<OVRCameraRig>();
        if (ovrCameraRig != null)
        {
            vrCamera = ovrCameraRig.centerEyeAnchor;
        }
        else
        {
            Debug.LogWarning("OVRCameraRig not found. Falling back to main camera.");
            vrCamera = Camera.main.transform;
        }

        unit = transform.parent;

        // Find the Canvas in the scene and check if it's not null
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            worldSpaceCanvas = canvas.transform;
        }
        else
        {
            Debug.LogError("No Canvas found in the scene. Please add a Canvas.");
            return;
        }

        transform.SetParent(worldSpaceCanvas);
        textComponent = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to this object
    }



    // Update is called once per frame
    void Update()
    {
        if (vrCamera != null && unit != null)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - vrCamera.position);
            transform.position = unit.position + offset;

            if (textComponent != null && unit.tag != null)
            {
                // Check the parent's tag and set the text color accordingly
                switch (unit.tag)
                {
                    case "Enemy":
                        textComponent.color = Color.red;
                        break;
                    case "NPC":
                        textComponent.color = new Color(1f, 0.5f, 0f); // Orange color (R: 1, G: 0.5, B: 0)
                        break;
                    case "Companion":
                        textComponent.color = Color.green;
                        break;
                    default:
                        textComponent.color = Color.white;
                        break;
                }
            }
        }
    }


}
