using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] float force, offset;

    Transform player;
    Rigidbody rb;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        direction = ((player.position + Vector3.forward * offset) - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(new Vector3(Random.Range(force / 2, force * 1.5f), Random.Range(force / 2, force * 1.5f), Random.Range(force / 2, force * 1.5f)), ForceMode.Impulse);
        rb.AddForce(direction * force * Time.deltaTime, ForceMode.Impulse);
    }
}
