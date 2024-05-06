using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    public HealthSystem playerHealth;
    public float hitRange = 2f; // Adjust this value to set the hit range
    public LayerMask playerLayer; // Specify the layer where the player belongs
    public float hitCooldown = 3f; // Cooldown duration between hits

    private Animator animator;
    private GameObject player;
    private bool playerInRange = false;
    private float lastHitTime = -Mathf.Infinity; // Initialize to a negative value to allow immediate hit

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if enough time has passed since the last hit
        if (Time.time - lastHitTime >= hitCooldown)
        {
            // Check for player object if not already found
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");

                // Check if player object exists
                if (player == null)
                {
                    Debug.LogError("Player object not found!");
                    return; // Exit Update method if player object not found
                }
            }

            // Calculate the distance between the zombie and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Check if the player is within the hit range and on the correct layer
            if (distanceToPlayer <= hitRange && player.layer == playerLayer)
            {
                // If player enters range while previously being outside
                if (!playerInRange)
                {
                    animator.SetTrigger("Hit");
                    playerInRange = true;
                    FindObjectOfType<AudioManager>().Play("Zombie1");
                    lastHitTime = Time.time; // Update last hit time
                    if (!(playerHealth.getHealth() <= 0))
                    {
                        playerHealth.DamageHealth();
                    }
                    
                    if(playerHealth.getHealth() <= 0)
                    {
                        playerHealth.destroyPlayer();
                    }

                }
            }
            else
            {
                // If player exits range while previously being inside
                if (playerInRange)
                {
                    // Cancel hit animation (if it's playing)
                    animator.ResetTrigger("Hit");
                    playerInRange = false;
                }
            }
        }
    }

    // Visualize the hit range in Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitRange);
    }

    // Detect collision with the player's hand during the hit animation
    // Method called at the end of the animation
    public void OnAnimationEnd()
    {
        // Calculate the distance between the zombie and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Check if the player is within the hit range and on the correct layer halfway through the animation
        if (distanceToPlayer <= hitRange && player.layer == playerLayer)
        {
            Debug.Log("Zombie hit collided with the player!");
        }
    }
}
