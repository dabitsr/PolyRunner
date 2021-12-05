using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceanimation : MonoBehaviour
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
        if (player.transform.position.z >= 400)
        {
            if (first)
            {
                audio.Play();
                first = false;
            }
            if (leftDoor.transform.position.x > -4) leftDoor.transform.position += new Vector3(-Time.deltaTime * 2, 0, 0);
            if (rightDoor.transform.position.x < 11) rightDoor.transform.position += new Vector3(Time.deltaTime * 2, 0, 0);
            if (player.transform.position.z >= 443 && player.transform.position.z < 900)
            {
                player.transform.position = new Vector3(0, -5, 1000);
            }
        }
    }
}
