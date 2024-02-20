using System.Collections;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    private Light myLight;
    private bool isLightOn = true;
    public float toggleInterval = 2.0f; // Interval in seconds

    void Start()
    {
        // Get the Light component from this GameObject
        myLight = GetComponent<Light>();
        // Start the Coroutine to toggle the light
        StartCoroutine(ToggleLight());
    }

    IEnumerator ToggleLight()
    {
        // This loop will run forever
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(toggleInterval);
            // Toggle the light on and off
            isLightOn = !isLightOn;
            myLight.enabled = isLightOn;
        }
    }
}
