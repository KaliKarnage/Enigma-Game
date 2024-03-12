using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int playerHealth = 100;
    public GameObject playerHUD;
    public GameObject deathUI;

    private void Start()
    {
        if (deathUI != null)
        {
            deathUI.SetActive(false);
        }

        if (playerHUD != null)
        {
            playerHUD.SetActive(true);
        }
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Player took damage. Current health: " + playerHealth);

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (playerHUD != null)
        {
            playerHUD.SetActive(false);
        }

        if (deathUI != null)
        {
            deathUI.SetActive(true);
        }

        StartCoroutine(DelayedAction(5));

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DelayedAction(float delayInSeconds)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delayInSeconds);

        // Code after the delay
        Debug.Log("This message is shown after a 5 seconds delay.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
