using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PirateController : MonoBehaviour
{
    [SerializeField] AudioClip punchSound;
    [SerializeField] bool dontUseNav = false;

    Animator anim;
    bool punching = false;

    // Start is called before the first frame update
    void Start()
    {
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
            anim.SetBool("isPunching", true);
            StartCoroutine(ResetRotation());
            if (!dontUseNav)
                GetComponent<NavMeshController>().SetDestination(transform);
        }
        if (other.gameObject.CompareTag("Despawner"))
            Destroy(gameObject);
    }

    IEnumerator ResetRotation()
    {
        yield return new WaitForSeconds(1.5f);
        punching = false;
    }

    void PlayPunchSound()
    {
        AudioPlayerController.PlayAudio(punchSound);
    }
}
