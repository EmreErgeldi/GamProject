using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 20f;
    private Transform target;
    NavMeshAgent agent;

    public Animator animator;

    private float distance;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
       
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
            animator.SetBool("chasePlayer", true);
            animator.SetBool("isAttacking", false);
            agent.isStopped = false;

            if(distance < agent.stoppingDistance)
            {
                FaceTarget();
                agent.isStopped = true;
                AttackTarget();
            }
        }

       
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackTarget()
    {
        animator.SetBool("chasePlayer", false);
        animator.SetBool("isAttacking", true);
    }
}
