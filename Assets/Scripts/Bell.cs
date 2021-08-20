using UnityEngine;

public class Bell : MonoBehaviour
{
    [Header("Settings")]
    public float ringRadius = 50.0f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ringRadius);
    }

    void OnShotHit()
    {
        Debug.Log("ShotHit");
        Ring();
    }

    void Ring()
    {
        Vector3 ringPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(ringPosition, ringRadius);
        foreach (var coll in colliders)
        {
            Debug.Log(coll);
            coll.SendMessage("OnSoundHear", ringPosition, SendMessageOptions.DontRequireReceiver);
        }
    }
}
