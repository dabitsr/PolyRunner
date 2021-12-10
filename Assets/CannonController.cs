using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] GameObject cannonBall;
    [SerializeField] ParticleSystem particle;
    [SerializeField] Vector2 fireRate;
    [SerializeField] float force;

    // Start is called before the first frame update
    void Start()
    {
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        particle.Play();
        GameObject b = Instantiate(cannonBall, transform.position, transform.rotation);
        b.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force , ForceMode.Impulse);

        Invoke("Fire", Random.Range(fireRate.x, fireRate.y));
    }
}
