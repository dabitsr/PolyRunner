using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;
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
        if (player.transform.position.z >= -25)
        {
            if (first)
            {
                audio.Play();
                first = false;
            }
            leftDoor.transform.position += new Vector3(-Time.deltaTime*2, 0, 0);
            rightDoor.transform.position += new Vector3(Time.deltaTime*2, 0, 0);
        }
    }
}
