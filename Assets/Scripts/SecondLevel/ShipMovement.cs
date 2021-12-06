using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject player;
    AudioSource audio;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= 50)
        {
            transform.position += new Vector3(Time.deltaTime * 30, 0, 0);
            transform.position += transform.up * Time.deltaTime * 20;
            transform.Rotate(1.0f * Time.deltaTime * 4, 0.0f, 0.0f, Space.Self);
            if (first)
            {
                audio.Play();
                first = false;
            }
        }
    }
}
