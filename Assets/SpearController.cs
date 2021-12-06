using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    Rigidbody rb;
    int stopCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude == 0)
        {
            stopCount++;

        }
        if (stopCount > 10 || transform.position.y < -10)
            Destroy(gameObject);

    }
}
