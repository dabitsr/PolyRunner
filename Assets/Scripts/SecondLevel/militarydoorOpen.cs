using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class militarydoorOpen : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
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
        if (player.transform.position.z >= 180)
        {
            if (first)
            {
                audio.Play();
                first = false;
            }
            door.transform.position += new Vector3(-Time.deltaTime * 3, 0, 0);
        }
    }
}
