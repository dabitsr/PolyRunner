using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtThrower : MonoBehaviour
{
    [SerializeField] GameObject dirt;
    [SerializeField] float throwForce;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ThrowDirt", 0, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowDirt()
    {
        GameObject d = Instantiate(dirt, transform.position, transform.rotation);
        d.GetComponent<Rigidbody>().AddForce(Random.Range(-throwForce / 4, throwForce / 4), Random.Range(throwForce / 2, throwForce), 0, ForceMode.Impulse);
        d.GetComponent<Rigidbody>().AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
    }
}
