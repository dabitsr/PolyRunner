using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPeopleSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject people;
    [SerializeField] float repeatRate, distance;
    [SerializeField] Transform player;

    bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.transform.position.z < distance && !spawning)
        {
            spawning = true;
            Invoke("SpawnPirate", 0);
        }
    }

    void SpawnPirate()
    {
        GameObject p = Instantiate(people, transform.position, transform.rotation);
        int n = p.transform.GetChild(0).childCount;
        p.transform.GetChild(0).GetChild(Random.Range(0, n)).gameObject.SetActive(true);
        p.GetComponent<NavMeshController>().SetDestination(player);
        Invoke("SpawnPirate", Random.Range(repeatRate / 2, repeatRate * 2));
    }
}
