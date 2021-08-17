using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    public UnityEvent<GameObject> onAlert;
    
    public void Shoot()
    {
        Destroy(transform.root.gameObject);
    }

    public void Alert(GameObject originator)
    {
        onAlert.Invoke(originator);
    }
}
