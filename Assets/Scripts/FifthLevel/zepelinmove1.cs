using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zepelinmove1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Time.deltaTime * 2, 0.0f, Time.deltaTime*4);
    }
}
