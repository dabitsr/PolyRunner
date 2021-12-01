using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] Transform destination;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetDestination(Transform destination)
    {
        agent = GetComponent<NavMeshAgent>();
        this.destination = destination;
        agent.destination = this.destination.position;
    }
}
