using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] float repeatRate;
    [SerializeField] bool randomRepeatRate;
    [SerializeField] Vector2 randomRange;
    [SerializeField] List<GameObject> prefabs;

    // Start is called before the first frame update
    void Start()
    {
        if (randomRepeatRate)
            Invoke("Spawn", Random.Range(randomRange.x, randomRange.y));
        else
            InvokeRepeating("Spawn", repeatRate, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject prefab = prefabs[Random.Range(0, prefabs.Count - 1)];
        Instantiate(prefab, transform.position, transform.rotation);

        if (randomRepeatRate)
            Invoke("Spawn", Random.Range(randomRange.x, randomRange.y));
    }
}
