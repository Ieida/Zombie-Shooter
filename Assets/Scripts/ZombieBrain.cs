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
    public Animator modelAnimator = null;
    // Variables
    ZombieBrainState state = ZombieBrainState.Idle;
    float idleTimer = 0.0f;
    float idleTime = 0.0f;
    Transform chaseTarget = null;

    void Update()
    {
        Wander();
        Idle();
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
                Vector3 randomPosition = Random.insideUnitSphere * 10.0f;
                randomPosition.y = 0.0f;
                Vector3 destination = transform.position + randomPosition;
                navAgent.SetDestination(destination);
                modelAnimator.SetBool("IsWalking", true);
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
                idleTime = Random.Range(2.0f, 5.0f);
                modelAnimator.SetBool("IsWalking", false);
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
                modelAnimator.SetBool("IsWalking", true);
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
        gameObject.SetActive(false);
        navAgent.isStopped = true;
        modelAnimator.SetTrigger("DieBackwards");
    }

    public void Die(Vector3 direction)
    {
        gameObject.SetActive(false);
        navAgent.isStopped = true;
        float dot = Vector3.Dot(navAgent.transform.forward, direction);
        if (dot > 0.0f)
        {
            modelAnimator.SetTrigger("DieForwards");
        }
        else
        {
            modelAnimator.SetTrigger("DieBackwards");
        }
    }
}
