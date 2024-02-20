using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public string playerUINotificationTextName = "Player UI Notification Text";
    private TMP_Text playerUINotificationText;
    private bool canSave = true;
    [SerializeField] private float saveCooldown = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canSave)
        {
            PlayerPrefs.SetFloat("CheckpointPositionX", other.transform.position.x);
            PlayerPrefs.SetFloat("CheckpointPositionY", other.transform.position.y);
            PlayerPrefs.SetFloat("CheckpointPositionZ", other.transform.position.z);
            PlayerPrefs.Save();
            Debug.LogError("Game Saved");

            playerUINotificationText = other.transform.Find(playerUINotificationTextName).GetComponent<TMP_Text>();
            if (playerUINotificationText != null)
            {
                playerUINotificationText.text = "Game Saved";
                playerUINotificationText.gameObject.SetActive(true);
                StartCoroutine(SaveCooldown());
            }
            else
            {
                Debug.LogError("Player UI Notification Text not found in the Player GameObject.");
            }
        }
    }

    private IEnumerator SaveCooldown()
    {
        canSave = false;
        yield return new WaitForSeconds(saveCooldown);
        canSave = true;
        if (playerUINotificationText != null)
        {
            playerUINotificationText.gameObject.SetActive(false);
        }
    }
}
