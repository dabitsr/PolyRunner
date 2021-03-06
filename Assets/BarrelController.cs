using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] int pushes;

    Vector3 d = Vector3.zero;
    float initMagnitude;
    int currentPushes = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (d != Vector3.zero)
        {
            if (currentPushes < pushes)
            {
                currentPushes++;
                GetComponent<Rigidbody>().AddForce(d * force * Time.deltaTime, ForceMode.Impulse);
            }
            /*
            if ((d - transform.position).magnitude > 3/4*initMagnitude)
                GetComponent<Rigidbody>().AddForce(d * force * Time.deltaTime, ForceMode.Impulse);
            */
        }
    }

    public void SetDestination(Transform destination)
    {
        d = (destination.position - transform.position).normalized;
        initMagnitude = (d - transform.position).magnitude;
    }
}
