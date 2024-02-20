using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private Renderer enemyRenderer;
    public Material defaultMaterial;
    public Material chaseMaterial;
    public Material enrageMaterial;
    public Material fleeMaterial;

    private EnemyNavigation enemyNavigation;
    public float patrolSpeed = 3f;
    public float chaseSpeed = 5f;
    public float chaseDistance = 10f;
    public float attackDistance = 5f;
    public float enrageThreshold = 30f;
    public float enrageChance = 15f;
    public float fleeChance = 10f;
    public float fleeDistance = 15f;
    public float reloadTime = 5f;
    public int ammo = 10;
    public Transform[] firePoints;
    public GameObject projectilePrefab;
    private int currentFirePointIndex = 0;
    private Enemy enemyScript;
    private bool isEnraged = false;
    private bool isFleeing = false;
    private bool hasEnraged;
    private bool isReloading = false;

    private void Start()
    {
        enemyScript = GetComponent<Enemy>();
        enemyRenderer = GetComponent<Renderer>();
        enemyNavigation = GetComponent<EnemyNavigation>();
        player = GameObject.FindGameObjectWithTag("Player");
        hasEnraged = false;
    }

    private void Update()
    {
        if (enemyScript == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (enemyScript.Health <= enrageThreshold && !hasEnraged)
        {
            float randomChance = UnityEngine.Random.Range(0f, 100f);
            if (randomChance <= enrageChance && !hasEnraged)
            {
                isEnraged = true;
                hasEnraged = true;
                enemyScript.Health = 100;
                enemyRenderer.material = enrageMaterial;
                
            }
            else if (randomChance <= enrageChance + fleeChance)
            {
                isFleeing = true;
                
            }
        }

        if (isFleeing)
        {
            FleeFromPlayer();
            enemyRenderer.material = fleeMaterial;
        }
        else if (distanceToPlayer <= attackDistance)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseDistance)
        {
            ChasePlayer();
            enemyRenderer.material = chaseMaterial;
        }
        else
        {
            Patrol();
            enemyRenderer.material = defaultMaterial;
        }
    }

    private void Patrol()
    {
        enemyNavigation.SetPatrolDestination();
    }

    private void ChasePlayer()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        Vector3 targetPosition = player.transform.position - directionToPlayer * 1f;
        enemyNavigation.SetAgentDestination(targetPosition);
    }

    private void AttackPlayer()
    {
        ShootPlayer();
    }

    private void FleeFromPlayer()
    {
        Vector3 fleeDirection = (transform.position - player.transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + fleeDirection, chaseSpeed * Time.deltaTime);
    }

    private void ShootPlayer()
    {
        FacePlayer();
        if (ammo > 0 && !isReloading)
        {
            Instantiate(projectilePrefab, firePoints[currentFirePointIndex].position, firePoints[currentFirePointIndex].rotation);
            ammo--;
            currentFirePointIndex = (currentFirePointIndex + 1) % firePoints.Length;
            if (ammo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * chaseSpeed);
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammo = 10;
        isReloading = false;
    }
}
