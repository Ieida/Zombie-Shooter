using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator armsAnimator = null;
    public Transform shootTransform = null;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            armsAnimator.Play("Fire", 0, 0.0f);

            Vector3 origin = shootTransform.position;
            Vector3 direction = shootTransform.forward;

            Collider[] colliders = Physics.OverlapSphere(origin, 20.0f);
            foreach (var coll in colliders)
            {
                if (coll.TryGetComponent(out Hitbox hitbox))
                {
                    hitbox.Alert(gameObject);
                }
            }

            bool isHit = Physics.Raycast(origin, direction, out RaycastHit hit);

            if (isHit)
            {
                bool isHitbox = hit.collider.TryGetComponent(out Hitbox hitbox);

                if (isHitbox)
                {
                    hitbox.Shoot();
                }
            }
        }
    }
}
