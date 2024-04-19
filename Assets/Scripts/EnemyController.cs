using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public HealthSystem playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(playerHealth.getHealth() <= 0))
        {
            enemy.SetDestination(player.position);
        }
    }
}
