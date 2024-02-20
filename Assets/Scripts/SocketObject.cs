using UnityEngine;

public class SocketObject : MonoBehaviour
{
    public GameObject cartridge; // The cartridge that will be socketed
    public Transform socketTransform; // The transform of the socket
    public float socketingDistance = 0.5f; // The maximum distance at which the cartridge will snap to the socket

    void Update()
    {
        // Calculate the distance between the cartridge and the socket
        float distance = Vector3.Distance(cartridge.transform.position, socketTransform.position);

        // If the cartridge is close enough to the socket
        if (distance <= socketingDistance)
        {
            // Snap the cartridge to the socket
            cartridge.transform.position = socketTransform.position;
            cartridge.transform.rotation = socketTransform.rotation;

            // Make the cartridge a child of the socket, so it moves with the socket
            cartridge.transform.SetParent(socketTransform);
        }
    }
}