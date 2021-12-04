using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndioController : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] float repeatRate, force;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ThrowSpear", 0, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowSpear()
    {
        GameObject s = Instantiate(spear, transform.position, transform.rotation, transform);
        Rigidbody rb = s.GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(Random.Range(force / 2, force * 2), Random.Range(force / 2, force * 2), Random.Range(force / 2, force * 2)));
        rb.AddForce(new Vector3(Random.Range(force / 2, force * 2), Random.Range(force / 2, force * 2), Random.Range(force / 2, force * 2)), ForceMode.Impulse);
    }
}
