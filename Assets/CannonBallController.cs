using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticle, explosionParticle;
    [SerializeField] List<AudioClip> audios;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ally"))
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().PlayAudio(audios[Random.Range(0, audios.Count)]);
            Instantiate(explosionParticle, transform.position, Quaternion.Euler(Vector3.zero)).Play();
            Destroy(gameObject);
        }
        else
            Instantiate(collisionParticle, transform.position, Quaternion.Euler(Vector3.zero)).Play();
    }
}
