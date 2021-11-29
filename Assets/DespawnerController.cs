using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Despawn(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Despawn(other.gameObject);   
    }

    void Despawn(GameObject g)
    {
        if (!g.CompareTag("Player") && !g.CompareTag("Ally") && !g.CompareTag("FloorPlayer"))
            Destroy(g);
    }
}