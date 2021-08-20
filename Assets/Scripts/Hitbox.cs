using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    public UnityEvent<GameObject> onHitAttacker = null;
    public UnityEvent<int> onHitDamage = null;
    public UnityEvent<Vector3> onHitDirection = null;

    public void Hit(GameObject attacker, Vector3 hitDirection, int damage = 0)
    {
        onHitAttacker.Invoke(attacker);
        if (damage != 0) onHitDamage.Invoke(damage);
        onHitDirection.Invoke(hitDirection);
    }
}
