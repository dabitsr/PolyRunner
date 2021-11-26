using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticle, explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ally"))
        {
            Instantiate(explosionParticle, transform.position, Quaternion.Euler(Vector3.zero)).Play();
            Destroy(gameObject);
        }
        else
            Instantiate(collisionParticle, transform.position, Quaternion.Euler(Vector3.zero)).Play();
    }
}
