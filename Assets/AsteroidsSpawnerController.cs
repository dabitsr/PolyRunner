using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawnerController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance;
    [SerializeField] Vector2 repeatRate;
    [SerializeField] List<GameObject> asteroids;

    bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (player.position.z >= distance)
        {
            if (!spawning)
            {
                Invoke("SpawnAsteroid", Random.Range(repeatRate.x, repeatRate.y));
                spawning = true;
            }
        }
    }

    void SpawnAsteroid()
    {
        int n = Random.Range(0, asteroids.Count - 1);

        GameObject a = Instantiate(asteroids[n], transform.position, transform.rotation, transform);

        Invoke("SpawnAsteroid", Random.Range(repeatRate.x, repeatRate.y));
    }
}
