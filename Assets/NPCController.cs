using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] float speed;
    Animator anim;
    Rigidbody rb;
    CharacterController controller;
    bool punching = false;
    Quaternion initRotation;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        punching = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Punch_LeftHand";
        if (!punching)
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);
        }

        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ally"))
        {
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
    }
}
