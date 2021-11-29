using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBalloon : MonoBehaviour
{
    private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 6 && !down) transform.position += transform.up * Time.deltaTime*0.5f;
        else
        {
            transform.position -= transform.up * Time.deltaTime*0.5f;
            down = true;
            if (transform.position.y < 5) down = false;
        }
    }
}
