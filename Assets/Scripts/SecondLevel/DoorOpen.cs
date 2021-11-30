using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject player;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= -25)
        {
            leftDoor.transform.position += new Vector3(-Time.deltaTime*2, 0, 0);
            rightDoor.transform.position += new Vector3(Time.deltaTime*2, 0, 0);
        }
        if (player.transform.position.z >= -5) audio.mute = true;
    }
}
