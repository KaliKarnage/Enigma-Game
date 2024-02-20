using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damageAmount = 3;
    public float destroyAfterSeconds = 15f;
    public float speed = 5f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damageAmount);
            }
        }
        else if (collision.gameObject.CompareTag("EnvironmentalHazard"))
        {
            collision.gameObject.GetComponent<ExplodingBarrel>().TakeDamage(damageAmount);
        }

        Destroy(gameObject);
    }
}
