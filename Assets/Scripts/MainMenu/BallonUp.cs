using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonUp : MonoBehaviour
{
    private bool down = false;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 20 && ! down) transform.position += transform.up * Time.deltaTime * 2;
        else {
            if (transform.position.y < 22 && !down) transform.position += transform.up * Time.deltaTime;
            else
            {
                transform.position -= transform.up * Time.deltaTime;
                down = true;
                if (transform.position.y <= 20) down = false;
            }
        }
    }
}
