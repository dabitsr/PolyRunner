using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField] List<GameObject> carPrefabs;
    [SerializeField] float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCar", 1, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomCar()
    {
        int car = Random.Range(0, carPrefabs.Count);
        Instantiate(carPrefabs[car], transform.position, transform.rotation, transform);
    }
}
