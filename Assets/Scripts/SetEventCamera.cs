using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class SetEventCamera : MonoBehaviour
{
    private void Awake()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas.renderMode == RenderMode.WorldSpace || canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            GameObject cameraGameObject = GameObject.FindGameObjectWithTag("MainCamera");
            if (cameraGameObject != null)
            {
                Camera mainCamera = cameraGameObject.GetComponent<Camera>();
                if (mainCamera != null)
                {
                    canvas.worldCamera = mainCamera;
                }
                else
                {
                    Debug.LogError("The object tagged 'MainCamera' does not have a Camera component.");
                }
            }
            else
            {
                Debug.LogError("No object with the tag 'MainCamera' was found in the scene.");
            }
        }
        else
        {
            Debug.LogError("Canvas render mode is not set to World Space or Screen Space - Camera.");
        }
    }
}
