using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance, force;

    Rigidbody rb;
    Vector3 position = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z <= distance)
        {
            if (position == Vector3.zero)
            {
                position = player.position;
            }
            transform.LookAt(position);
            rb.AddRelativeForce(Vector3.forward * force * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
