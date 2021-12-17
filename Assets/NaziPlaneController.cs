using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaziPlaneController : MonoBehaviour
{
    [SerializeField] float speed, distance;
    [SerializeField] Transform player;

    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && transform.position.z - player.position.z < distance)
        {
            started = true;
        } else if (started)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
