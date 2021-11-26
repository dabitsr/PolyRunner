using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed, wheelRotationSpeed;
    [SerializeField] List<GameObject> wheels;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.x < 90 && transform.rotation.z < 90)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        foreach (GameObject wheel in wheels)
            wheel.transform.Rotate(Vector3.right * wheelRotationSpeed * Time.deltaTime);

        if (transform.position.y < -10)
            Destroy(gameObject);
    }
}
