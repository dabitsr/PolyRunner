using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PowerBeamController : MonoBehaviour
{
    [SerializeField] Transform target, player;
    [SerializeField] float applyWhenPosition;
    [SerializeField] bool useAgent;

    bool destination = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z <= applyWhenPosition)
        {
            if (!destination)
            {
                transform.GetChild(7).GetComponent<NavMeshController>().SetDestination(player);
                destination = true;
            }
            transform.LookAt(target);
        }
    }
}
