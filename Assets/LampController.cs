using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance, force;
    [SerializeField] ParticleSystem flames;
    [SerializeField] bool fallLeft;
    [SerializeField] Rigidbody rb;
    [SerializeField] int forcePushes;

    int currentPushes = 0;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z <= distance)
        {
            if (currentPushes <= forcePushes)
            {
                Vector3 f;
                if (fallLeft) f = -Vector3.right;
                else f = Vector3.right;

                rb.AddRelativeForce(f * force * Time.deltaTime, ForceMode.Impulse);

                currentPushes++;
            }
        }

        if (fallLeft && transform.eulerAngles.z >= 88 && transform.eulerAngles.z <= 100)
        {
            flames.transform.eulerAngles = Vector3.forward * -90;
            flames.Play();
        }

        if (!fallLeft && transform.eulerAngles.z <= 272 && transform.eulerAngles.z >= 100)
        {
            flames.transform.eulerAngles = Vector3.forward * 90;
            flames.Play();
        }
    }
}
