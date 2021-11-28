using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnerController : MonoBehaviour
{
    [SerializeField] float repeatRate;
    [SerializeField] GameObject peoplePrefab;

    BoxCollider boxCollider;
    Vector2 spawnRangeZ, spawnRangeX; // x: izquierda, y: derecha
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        spawnRangeZ = new Vector2(boxCollider.bounds.center.z - boxCollider.bounds.size.z / 2, boxCollider.bounds.center.z + boxCollider.bounds.size.z / 2);
        spawnRangeX = new Vector2(boxCollider.bounds.center.x - boxCollider.bounds.size.x / 2, boxCollider.bounds.center.x + boxCollider.bounds.size.x / 2);
        Invoke("SpawnPeople", 0);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > transform.position.z)
            Destroy(gameObject);
    }

    void SpawnPeople()
    {
        Vector3 pos = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), transform.position.y, Random.Range(spawnRangeZ.x, spawnRangeZ.y));
        GameObject p = Instantiate(peoplePrefab, pos, transform.rotation);
        int n = p.transform.GetChild(0).childCount;
        p.transform.GetChild(0).GetChild(Random.Range(0, n)).gameObject.SetActive(true);

        Invoke("SpawnPeople", Random.Range(repeatRate / 2, repeatRate * 1.5f));
    }
}
