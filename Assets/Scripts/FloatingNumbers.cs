using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingNumbers : MonoBehaviour
{
    public GameObject damagePopupPrefab;
    public Enemy enemy;
    private int lastHealth;

    void Start()
    {
        lastHealth = enemy.Health;
    }

    void Update()
    {
        if (lastHealth > enemy.Health)
        {
            ShowDamagePopup(lastHealth - enemy.Health, Color.red);
        }
        else if (lastHealth < enemy.Health)
        {
            ShowDamagePopup(enemy.Health - lastHealth, Color.green);
        }
        lastHealth = enemy.Health;
    }

    void ShowDamagePopup(int amount, Color color)
    {
        GameObject popup = Instantiate(damagePopupPrefab, enemy.transform.position, Quaternion.identity);
        TextMeshPro textMesh = popup.GetComponent<TextMeshPro>();
        textMesh.text = amount.ToString();
        textMesh.color = color;
        StartCoroutine(MoveAndFadeText(popup, textMesh));
    }

    IEnumerator MoveAndFadeText(GameObject popup, TextMeshPro textMesh)
    {
        float duration = 2f; // duration of the effect
        float speed = 1f; // speed of the movement
        Color originalColor = textMesh.color;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            // Move upwards
            popup.transform.Translate(Vector3.up * speed * Time.deltaTime);
            // Fade out
            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, normalizedTime));
            yield return null;
        }
        Destroy(popup);
    }
}
