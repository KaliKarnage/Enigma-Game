using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private List<Transform> movePositions = new List<Transform>();
    private NavMeshAgent m_Agent;
    private Transform currentDestination;

    public float checkDistance = 5f; // Set the distance to check for obstacles
    public float checkRadius = 1f; // Set the radius of the checking sphere

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        // Find all GameObjects with the "EnemyNavPoint" tag
        GameObject[] navPoints = GameObject.FindGameObjectsWithTag("EnemyNavPoint");

        // Iterate through the array and add the Transform components to the movePositions list
        foreach (GameObject navPoint in navPoints)
        {
            movePositions.Add(navPoint.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Transform RandomDestination()
    {
        if (movePositions.Count > 0)
        {
            int rd = Random.Range(0, movePositions.Count);
            return movePositions[rd];
        }

        return null;
    }

    public void SetAgentDestination(Vector3 destination)
    {
        m_Agent.destination = destination;
    }

    private bool CheckForObstacle()
    {
        RaycastHit hit;

        // Cast a sphere in front of the enemy and check if it hits any obstacles
        if (Physics.SphereCast(transform.position, checkRadius, transform.forward, out hit, checkDistance))
        {
            // If the sphere hits an obstacle, return true
            if (hit.collider.gameObject.CompareTag("Environment"))
            {
                return true;
            }
        }

        // If no obstacle is hit, return false
        return false;
    }

    public void SetPatrolDestination()
    {
        // Before setting a new patrol destination, check for obstacles
        if (!CheckForObstacle())
        {
            currentDestination = RandomDestination();
            m_Agent.destination = currentDestination.position;
        }
    }
}
