using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawnerController : MonoBehaviour
{
    [SerializeField] List<GameObject> barrels;
    [SerializeField] float repeatRate;
    [SerializeField] Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject barrel = barrels[Random.Range(0, barrels.Count - 1)];

        GameObject b = Instantiate(barrel, transform.position, transform.rotation);
        b.GetComponent<BarrelController>().SetDestination(destination);
        Invoke("Spawn", repeatRate);
    }
}
