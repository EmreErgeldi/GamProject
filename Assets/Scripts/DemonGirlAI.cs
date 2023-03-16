using UnityEngine;
using UnityEngine.AI;

public class DemonGirlAI : MonoBehaviour
{
    public float lookRadius = 10f;
    
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

            if(distance < agent.stoppingDistance)
            {
                FaceTarget();
            }
        }

       
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
