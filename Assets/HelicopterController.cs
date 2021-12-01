using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    [SerializeField] float spinPropellerSpeed, speed, upSpeed, downSpeed, maxHeight, t;
    [SerializeField] ParticleSystem particle = null;
    [SerializeField] bool useTorque;
    Transform mainPropeller, smallPropeller;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (spinPropellerSpeed > 0)
        {
            mainPropeller = transform.GetChild(0);
            smallPropeller = transform.GetChild(1);
        }
        upSpeed += Random.Range(0, upSpeed / 3);
        speed = upSpeed;

        int r = Random.Range(0, 2);
        if (r == 0) transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (useTorque)
            rb.AddTorque(Vector3.up * Time.deltaTime, ForceMode.Impulse);

        if (transform.position.y > maxHeight - maxHeight / 3)
        {
            speed = Mathf.Lerp(speed, downSpeed, t);
            if (particle != null)
                particle.Stop();
        }
        else if (transform.position.y <= maxHeight / 4)
        {
            speed = Mathf.Lerp(speed, upSpeed, t);
            if (particle != null)
                particle.Play();
        }
        rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
        if (spinPropellerSpeed > 0)
            SpinPropellers();
    }

    void SpinPropellers()
    {
        mainPropeller.Rotate(Vector3.up * spinPropellerSpeed * Time.deltaTime);
        smallPropeller.Rotate(Vector3.right * spinPropellerSpeed * Time.deltaTime);
    }
}
