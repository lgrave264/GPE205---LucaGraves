using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the blocker
    public Transform player; // Reference to the player object

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the blocker to the player
            Vector3 directionToPlayer = transform.position - player.position;
            directionToPlayer.y = 0f; // Ignore vertical movement

            // Calculate the movement amount based on the direction and speed
            float movementAmount = Mathf.Sign(directionToPlayer.x) * moveSpeed * Time.deltaTime;

            // Move the blocker left or right away from the player
            transform.Translate(new Vector3(movementAmount, 0f, 0f));
        }
        else
        {
            Debug.LogWarning("Player reference not assigned!");
        }
    }
}
