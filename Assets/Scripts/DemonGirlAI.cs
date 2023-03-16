using UnityEngine;
using UnityEngine.AI;

public class DemonGirlAI : MonoBehaviour
{
    public float lookRadius = 10f;
    
    private Transform target;
    NavMeshAgent agent;

    private float distance;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }
}
