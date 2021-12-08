using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmove : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= 100)
        {
            transform.position += new Vector3(-Time.deltaTime * 2, 0.0f, Time.deltaTime * 2);
        }
    }
}
