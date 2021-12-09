using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance, speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z <= distance)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
    }
}
