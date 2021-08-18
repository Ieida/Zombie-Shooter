using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    public UnityEvent onShot;
    public UnityEvent<GameObject> onAlert;
    
    public void Shoot()
    {
        onShot.Invoke();
    }

    public void Alert(GameObject originator)
    {
        onAlert.Invoke(originator);
    }
}
