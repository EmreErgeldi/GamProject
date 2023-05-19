using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIRanged : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;
    public float follow_distance = 10f;
    private float maxradius = 30f;
    NavMeshAgent agent;
    public Animator animator;
    public GameObject arrow;
    public Transform firePoint;
    float distance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        distance = Vector3.Distance(transform.position, player.position);
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        //Look Player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);

        //Move
        if (distance >= follow_distance && distance <= maxradius)
        {
            agent.SetDestination(player.position);
            animator.SetBool("chasePlayer", true);
            animator.SetBool("isAttacking", false);
        }
        else if (distance >= maxradius)
        {
            animator.SetBool("chasePlayer", false);
            animator.SetBool("isAttacking", false);
        }
        else if (distance < follow_distance)
        {
            AttackTarget();
        }

        //Optimize distance calculation
        distance = Vector3.Distance(transform.position, player.position);
    }

    void AttackTarget()
    {
        animator.SetBool("chasePlayer", false);
        animator.SetBool("isAttacking", true);
    }

    void AnimationEvent()
    {
        Instantiate(arrow, firePoint.position, transform.rotation);
    }
}

