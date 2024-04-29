using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float moveSpeed = 5f; // Movement speed of the chaser
    public float chaseDistance = 10f; // Distance within which the chaser starts chasing
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float obstacleCheckDistance = 1f; // Distance to check for obstacles
    public string noAccessTag = "NoAccess"; // Tag for obstacles the chaser can't move through

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the chaser is within chase distance
            if (distanceToPlayer <= chaseDistance)
            {
                // Calculate the direction to the player
                Vector3 directionToPlayer = (player.position - transform.position).normalized;
                directionToPlayer.y = 0f; // Ignore vertical movement

                // Rotate towards the direction of movement
                transform.rotation = Quaternion.LookRotation(directionToPlayer);

                // Check for obstacles
                if (!CheckObstacle())
                {
                    // Move towards the player
                    transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime, Space.World);
                }
            }
        }
        else
        {
            Debug.LogWarning("Player reference not assigned!");
        }
    }

    bool CheckObstacle()
    {
        // Cast a ray forward to check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, obstacleCheckDistance, obstacleLayer))
        {
            // Check if the hit object has the specified tag
            if (hit.collider.CompareTag(noAccessTag))
            {
                // Found an obstacle with the NoAccess tag
                return true;
            }
        }
        return false;
    }
}
