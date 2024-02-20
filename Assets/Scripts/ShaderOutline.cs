using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderOutline : MonoBehaviour
{
    // SerializeField allows you to set these values from the Unity inspector,
    // while keeping the fields private to maintain encapsulation.
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;

    // This Renderer will hold the Renderer component of the outline object.
    private Renderer outlineRenderer;

    // Start is called before the first frame update.
    void Start()
    {
        // Call CreateOutline with the material, scale, and color set in the inspector.
        // Make sure the method name exactly matches the one defined below.
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);

        // If the Renderer is successfully created, enable it.
        if (outlineRenderer != null)
        {
            outlineRenderer.enabled = true;
        }
    }

    // Update is called once per frame.
    void Update()
    {
        // This script does not use Update, but you might want to add logic here later.
    }

    // This method creates an outline object, sets its material, color, and scale,
    // and then disables certain components to prevent rendering and physics issues.
    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        // Instantiate a copy of this game object at the same position and rotation.
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform.parent);

        // Get the Renderer component of the new object.
        Renderer rend = outlineObject.GetComponent<Renderer>();

        // Check if the Renderer component is found.
        if (rend != null)
        {
            // Assign the provided material to the Renderer.
            rend.material = outlineMat;
            // Set the color and scale properties of the material.
            rend.material.SetColor("_OutlineColor", color);
            rend.material.SetFloat("_Scale", scaleFactor);
            // Ensure the outline object does not cast shadows.
            rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            // Disable all other components on the outline object to prevent
            // unintended effects like double scripting or physics interactions.
            foreach (var comp in outlineObject.GetComponents<Component>())
            {
                if (!(comp is Transform) && !(comp is Renderer))
                {
                    Destroy(comp);
                }
            }

            // The renderer is initially disabled; it can be enabled outside this method if needed.
            rend.enabled = false;
            // Return the Renderer component of the outline object.
            return rend;
        }

        // If the Renderer component was not found, return null.
        return null;
    }
}
