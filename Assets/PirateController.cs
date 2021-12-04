using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    bool punching = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Ally")) && !punching)
        {
            other.gameObject.GetComponent<CollisionManager>().KillAlly(false);
            punching = true;
            /*
            boxCollider.enabled = false;
            rb.useGravity = false;
            */
            Invoke("PlayPunchSound", 0.2f);
            Vector3 targetDirection = other.transform.position - transform.position;
            transform.LookAt(targetDirection);
            anim.SetTrigger("punch");
            StartCoroutine(ResetRotation());
        }
        if (other.gameObject.CompareTag("Despawner"))
            Destroy(gameObject);
    }

    IEnumerator ResetRotation()
    {
        yield return new WaitForSeconds(1.5f);
        punching = false;
    }
}
