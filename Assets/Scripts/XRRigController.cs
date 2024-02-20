using UnityEngine;
using System.Collections;

public class XRRigController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectivePanels;
    [SerializeField] private DoorController doorController;
    private int batteryCount = 0;

    public int BatteryCount
    {
        get { return batteryCount; }
    }

    void Start()
    {
        // Initially, all panels are inactive
        foreach (var panel in objectivePanels)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // Update the active state of objective panels based on the current battery count
        for (int i = 0; i < objectivePanels.Length; i++)
        {
            objectivePanels[i].SetActive(i == batteryCount);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            batteryCount++;
            other.gameObject.SetActive(false);

            // Handle the special case when batteryCount is 2
            if (batteryCount == 2)
            {
                // Activate Objective panel (2) and start the coroutine to deactivate it after 5 seconds
                objectivePanels[1].SetActive(true);
                StartCoroutine(DeactivatePanelAfterDelay(1, 5));
            }
        }
    }

    IEnumerator DeactivatePanelAfterDelay(int panelIndex, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Deactivate the panel after the delay
        objectivePanels[panelIndex].SetActive(false);

        // If we are deactivating Objective panel (2), we should activate Objective panel (3)
        if (panelIndex == 1) // Objective panel (2) is at index 1
        {
            batteryCount++; // Increase batteryCount to move the logic to the next panel
        }
    }

    void LateUpdate()
    {
        // If the door is opening, activate Objective panel (4) and deactivate all others
        if (doorController.isOpening)
        {
            // Deactivate all other panels
            foreach (GameObject panel in objectivePanels)
            {
                panel.SetActive(false);
            }
            // Activate Objective panel (4)
            objectivePanels[4].SetActive(true);
        }
        else
        {
            // If the door is not opening, ensure Objective panel (4) is deactivated
            objectivePanels[3].SetActive(false);
        }
    }


    public void ResetBatteryCount()
    {
        batteryCount = 0;
    }

    public void UseBattery()
    {
        if (batteryCount > 0)
        {
            batteryCount--;
        }
    }
}
