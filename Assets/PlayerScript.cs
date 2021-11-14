using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animation anim;
    public float frontSpeed, lateralSpeed, maxLeft, maxRight;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // TP al respawn
        //transform.position = Vector3.zero;
        transform.position = new Vector3(-2.2f, 0.86f, -9);
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;
        move = Input.GetAxis("Horizontal");
        if (transform.position.x >= maxRight && move > 0) move = 0;
        else if (transform.position.x <= maxLeft && move < 0) move = 0;
        transform.position = new Vector3(transform.position.x + move * lateralSpeed, transform.position.y, transform.position.z + frontSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionStay(Collision collision)
    {
        rb.angularVelocity = Vector3.zero;
    }
}

