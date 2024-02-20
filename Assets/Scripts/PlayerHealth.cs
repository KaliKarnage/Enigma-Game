using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int health;

    public Image progressBar;

    void Start()
    {
        health = maxHealth;
    }

    private void UpdateProgressBar()
    {
        float fillAmount = (float)health / 100f;
        progressBar.fillAmount = fillAmount;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health <= 0)
        {
            // Handle player death or respawn logic here
        }
    }
}
