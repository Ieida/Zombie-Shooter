using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator gunAnimator = null;
    public Transform shootTransform = null;
    [Header("Settings")]
    public float range = 50.0f;
    public int damage = 1;

    public void Shoot()
    {
        gunAnimator.Play("Fire", 0, 0.0f);

        Vector3 origin = shootTransform.position;
        Vector3 direction = shootTransform.forward;

        bool isHit = Physics.Raycast(origin, direction, out RaycastHit hit, range);

        if (isHit)
        {
            hit.collider.SendMessage("OnShotHit", SendMessageOptions.DontRequireReceiver);
        }

        Collider[] colliders = Physics.OverlapSphere(origin, 20.0f);
        foreach (var coll in colliders)
        {
            coll.SendMessage("OnShotHear", SendMessageOptions.DontRequireReceiver);
        }
    }
}
