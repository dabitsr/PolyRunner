using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] bool updateDestination;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (destination != null)
            agent.destination = destination.position;
        else destination = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateDestination)
            agent.destination = destination.position;
    }

    public void SetDestination(Transform destination)
    {
        agent = GetComponent<NavMeshAgent>();
        this.destination = destination;
        agent.destination = this.destination.position;
    }

    public void SetDestination(Vector3 destination)
    {
        agent = GetComponent<NavMeshAgent>();
        this.destination.position = destination;
        agent.destination = this.destination.position;
    }
}
