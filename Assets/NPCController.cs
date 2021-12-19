using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AudioClip punchSound;
    Animator anim;
    Rigidbody rb;
    CharacterController controller;
    public bool punching = false;
    Quaternion initRotation;
    BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        initRotation = transform.rotation;
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!punching)
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);
        }

        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Ally") || other.gameObject.CompareTag("Player")) && !punching)
        {
            other.gameObject.GetComponent<CollisionManager>().KillAlly(false);
            punching = true;
            boxCollider.enabled = false;
            rb.useGravity = false;
            controller.enabled = false;
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
        transform.rotation = initRotation;
        punching = false;
        controller.enabled = true;
        rb.useGravity = true;
    }

    void PlayPunchSound()
    {
        AudioPlayerController.PlayAudio(punchSound);
    }
}
