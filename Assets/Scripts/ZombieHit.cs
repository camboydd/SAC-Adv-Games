using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    public float hitRange = 2f; // Adjust this value to set the hit range

    private Animator animator;
    private Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming player tag is "Player"
    }

    void Update()
    {
        // Check conditions for hitting (e.g., proximity to player)
        bool shouldHit = CheckHitCondition();

        // Set the "Attack" trigger parameter in the animator if conditions are met
        if (shouldHit)
        {
            animator.SetTrigger("Hit");
        }
    }

    bool CheckHitCondition()
    {
        // Calculate the distance between the zombie and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the hit range
        if (distanceToPlayer <= hitRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
