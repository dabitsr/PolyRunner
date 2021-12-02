using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance, force;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < 15)
            Move();
        //if (player.position.z >= transform.position.z - distance)
            
    }

    void Move()
    {
        rb.AddRelativeForce(Vector3.forward * force * Time.deltaTime, ForceMode.Impulse);
    }
}
