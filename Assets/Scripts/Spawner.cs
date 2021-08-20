using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject spawnee;

    public void Spawn()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
    }
}
