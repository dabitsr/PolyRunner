using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;
    [SerializeField] float throwForce, repeatRate, maxForce, minForce;
    [SerializeField] bool useThrowerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Throw", Random.Range(2, 8));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Throw()
    {
        GameObject obj = objects[Random.Range(0, objects.Count)];
        GameObject d = Instantiate(obj, transform.position, transform.rotation);
        if (useThrowerTransform)
            d.GetComponent<Rigidbody>().rotation = transform.rotation;

        if (minForce != maxForce)
            d.GetComponent<Rigidbody>().AddRelativeForce(0, Random.Range(minForce, maxForce), Random.Range(-10, 10), ForceMode.Impulse);
        else
            d.GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-throwForce / 4, throwForce / 4), Random.Range(throwForce / 2, throwForce), 0, ForceMode.Impulse);
        d.GetComponent<Rigidbody>().AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        Invoke("Throw", Random.Range(2, 8));
    }
}
