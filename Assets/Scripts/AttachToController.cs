using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachToController : MonoBehaviour
{
    public GameObject objectToAttach;

    void Start()
    {
        GameObject controller = GameObject.Find("RightHand Controller");
        if (controller != null && objectToAttach != null)
        {
            objectToAttach.transform.SetParent(controller.transform);
            objectToAttach.transform.localPosition = Vector3.zero;
            objectToAttach.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogWarning("Controller or object to attach not found.");
        }
    }
}