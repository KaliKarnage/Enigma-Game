using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerController playerController;

    void Update()
    {
        if (playerController != null)
        {
            healthSlider.value = playerController.playerHealth;
        }
    }
}
