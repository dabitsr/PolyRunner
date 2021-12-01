using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField] List<GameObject> carPrefabs;
    [SerializeField] float repeatRate;
    [SerializeField] List<Transform> destinations;
    [SerializeField] bool randomRepeatRate;

    // Start is called before the first frame update
    void Start()
    {
        if (randomRepeatRate)
            Invoke("SpawnRandomCar", Random.Range(repeatRate / 2, repeatRate * 1.5f));
        else 
            InvokeRepeating("SpawnRandomCar", 1, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomCar()
    {
        int carPrefab = Random.Range(0, carPrefabs.Count);
        GameObject car = Instantiate(carPrefabs[carPrefab], transform.position, transform.rotation, transform);
        car.GetComponent<NavMeshController>().SetDestination(destinations[Random.Range(0, destinations.Count)]);

        if (randomRepeatRate)
            Invoke("SpawnRandomCar", Random.Range(repeatRate / 2, repeatRate * 1.5f));
    }
}
