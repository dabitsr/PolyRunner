using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSpawnerController : MonoBehaviour
{
    [SerializeField] List<GameObject> pirates;
    [SerializeField] float repeatRate;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPirate", Random.Range(repeatRate / 2, repeatRate * 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPirate()
    {
        int n = Random.Range(0, pirates.Count);
        GameObject p = Instantiate(pirates[n], transform.position, transform.rotation, transform);
        p.GetComponent<NavMeshController>().SetDestination(player);
        Invoke("SpawnPirate", Random.Range(repeatRate / 2, repeatRate * 2));
    }
}
