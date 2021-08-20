using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator gunAnimator = null;
    public Transform shootTransform = null;
    [Header("Settings")]
    public LayerMask hitMask = default(LayerMask);
    public LayerMask alertMask = default(LayerMask);
    public float range = 50.0f;
    public int damage = 1;

    public void Shoot()
    {
        gunAnimator.Play("Fire", 0, 0.0f);

        Vector3 origin = shootTransform.position;
        Vector3 direction = shootTransform.forward;

        Collider[] colliders = Physics.OverlapSphere(origin, 20.0f, alertMask);
        foreach (var coll in colliders)
        {
            if (coll.TryGetComponent(out Hitbox hitbox))
            {
                hitbox.Hit(gameObject, direction);
            }
        }

        bool isHit = Physics.Raycast(origin, direction, out RaycastHit hit, range, hitMask);

        if (isHit)
        {
            bool isHitbox = hit.collider.TryGetComponent(out Hitbox hitbox);

            if (isHitbox)
            {
                hitbox.Hit(gameObject, direction, damage);
            }
        }
    }
}
