using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaziController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distanceToWalk, distanceToShoot;

    Animator anim;
    bool walking = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z < distanceToWalk)
        {

        }
    }
}
