using UnityEngine;

public class Bell : MonoBehaviour
{
    [Header("Settings")]
    public float ringRadius = 50.0f;
    public Vector3 ringPositionOffset = Vector3.zero;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 ringPosition = transform.position + ringPositionOffset;
        Gizmos.DrawSphere(ringPosition, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ringPosition, ringRadius);
    }

    void OnShotHit()
    {
        Ring();
    }

    void Ring()
    {
        Vector3 ringPosition = transform.position + ringPositionOffset;
        Collider[] colliders = Physics.OverlapSphere(ringPosition, ringRadius);
        foreach (var coll in colliders)
        {
            coll.SendMessage("OnSoundHear", ringPosition, SendMessageOptions.DontRequireReceiver);
        }
    }
}
