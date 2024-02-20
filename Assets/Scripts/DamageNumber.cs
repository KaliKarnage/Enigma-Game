using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private float lifetime = 1.5f; // How long the damage number stays visible
    [SerializeField] private float moveSpeed = 2f; // How fast the damage number moves upward
    [SerializeField] private float placementJitter = 0.5f; // Random offset to give some variation to the spawn position

    private TextMeshProUGUI textMesh; // Reference to the TextMeshProUGUI component
    private float moveY; // Tracks the upward movement

    private void Awake()
    {
        // Initialize the TextMeshProUGUI component from children
        textMesh = GetComponentInChildren<TextMeshProUGUI>(true); // true to include inactive

        // If the component is not found, log an error
        if (textMesh == null)
        {
            Debug.LogError("TextMeshProUGUI component not found in children of the GameObject", this);
        }
    }

    private void Update()
    {
        if (textMesh == null)
        {
            return; // No need to proceed if textMesh is not found
        }

        // Move the damage number up by updating its anchored position
        moveY += moveSpeed * Time.deltaTime;
        if (textMesh.rectTransform != null)
        {
            textMesh.rectTransform.anchoredPosition += new Vector2(0, moveY);
        }

        // Gradually fade out the damage number over its lifetime
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject); // Destroy the damage number after its lifetime expires
        }
        else
        {
            // Fade the alpha based on the remaining lifetime
            textMesh.alpha = Mathf.Clamp01(lifetime);
        }
    }

    public void SetDamage(int damageAmount)
    {
        if (textMesh != null)
        {
            textMesh.text = damageAmount.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI is not initialized", this);
        }
    }
}
