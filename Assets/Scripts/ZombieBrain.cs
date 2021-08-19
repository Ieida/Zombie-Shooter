using UnityEngine;
using UnityEngine.AI;

public class ZombieBrain : MonoBehaviour
{
    enum ZombieBrainState
    {
        Idle,
        Wander,
        Chase
    }

    [Header("Dependencies")]
    public NavMeshAgent navAgent = null;
    // Variables
    ZombieBrainState state = ZombieBrainState.Idle;
    float idleTimer = 0.0f;
    float idleTime = 0.0f;
    Transform chaseTarget = null;

    void Update()
    {
        Idle();
        Wander();
        Chase();
    }

    void Idle()
    {
        if (state == ZombieBrainState.Idle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                state = ZombieBrainState.Wander;
                Vector3 randomPosition = Random.insideUnitSphere;
                randomPosition.y = 0.0f;
                Vector3 destination = transform.position + randomPosition;
                navAgent.SetDestination(destination);
            }
        }
    }

    void Wander()
    {
        if (state == ZombieBrainState.Wander)
        {
            if (navAgent.remainingDistance < 0.5f)
            {
                state = ZombieBrainState.Idle;
                idleTimer = 0.0f;
                idleTime = Random.Range(0.0f, 5.0f);
            }
        }
    }

    void Chase()
    {
        if (state == ZombieBrainState.Chase)
        {
            float distance = Vector3.Distance(navAgent.destination, chaseTarget.position);
            if (distance > 0.5f)
            {
                navAgent.SetDestination(chaseTarget.position);
            }
        }
    }

    public void Alert(GameObject originator)
    {
        state = ZombieBrainState.Chase;
        chaseTarget = originator.transform;
    }

    public void Die()
    {
        Destroy(transform.root.gameObject);
    }
}
