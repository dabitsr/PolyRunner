using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrunkKingController : MonoBehaviour
{
    [SerializeField] Vector2 changeDirectionRate;
    [SerializeField] NavMeshController navMeshController;
    [SerializeField] Transform dest;
    Transform initPos;
    bool punching = false;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform;
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeDirection()
    {
        if (!punching)
            Invoke("ChangeDirection", Random.Range(changeDirectionRate.x, changeDirectionRate.y));

        Vector2 p = Random.insideUnitCircle * 3;
        dest.position = new Vector3(initPos.position.x + p.x, initPos.position.y, initPos.position.z + p.y);
        NavMeshHit hit;
        NavMesh.SamplePosition(dest.position, out hit, 4, 1);
        dest.position = hit.position;
        navMeshController.SetDestination(dest);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ally") || other.gameObject.CompareTag("Player"))
        {
            navMeshController.SetDestination(transform);
            punching = true;
        }
    }
}
