using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * 5, transform.position.y + Input.GetAxis("Vertical") * 5, transform.position.z);
    }
}
