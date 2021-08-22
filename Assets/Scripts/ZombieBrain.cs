using UnityEngine;
using UnityEngine.AI;

public class ZombieBrain : MonoBehaviour
{
    [Header("Dependencies")]
    public NavMeshAgent navAgent = null;
    public Animator modelAnimator = null;
    // Variables

    void OnShotHit()
    {
        Die();
    }

    void OnShotHear(Vector3 shotPosition)
    {
        Move(shotPosition);
    }

    void OnSoundHear(Vector3 soundPosition)
    {
        Move(soundPosition);
    }

    public void Die()
    {
        navAgent.isStopped = true;
        modelAnimator.SetTrigger("DieBackwards");
    }

    public void Move(Vector3 position)
    {
        navAgent.SetDestination(position);
        modelAnimator.SetBool("IsWalking", true);
    }

    public void StopMoving()
    {
        navAgent.SetDestination(navAgent.transform.position);
        modelAnimator.SetBool("IsWalking", false);
    }
}
