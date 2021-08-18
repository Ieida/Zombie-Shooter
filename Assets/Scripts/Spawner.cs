using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject spawnee = null;

    public void Spawn()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
    }
}
