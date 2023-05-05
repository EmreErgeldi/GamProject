using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIRanged : MonoBehaviour
{

    private Transform player;
    public Vector3 offset;
    public float speed = 10f;
    public float follow_distance =10f;
    private float maxradius = 30f;
    NavMeshAgent agent;
    public Animator animator;
    float distance;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
         distance = Vector3.Distance(transform.position, player.position);
         FollowPlayer(distance);
    }
    private void FollowPlayer(float direction)
    { 
        //Look Player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);
        //Move
        if (distance >= follow_distance && distance <= maxradius)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
            animator.SetBool("chasePlayer", true);
        }
        else if(distance >= maxradius)
        {
            animator.SetBool("chasePlayer", false);
        }
        else if (distance < follow_distance)
        {
            AttackTarget();
        }
        
    }

    void AttackTarget()
    {
        animator.SetBool("chasePlayer", false);
        animator.SetBool("isAttacking", true);
    }
}
