using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticle, explosionParticle;
    [SerializeField] List<AudioClip> audios;
    [SerializeField] GameObject audioPlayer;
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
            int n = Random.Range(0, audios.Count);
            AudioPlayerController.PlayAudio(audios[n]);
            //GameObject.Find("Player").GetComponent<PlayerScript>().PlayAudio(audios[n]);
            Instantiate(explosionParticle, transform.position, Quaternion.Euler(Vector3.zero), transform).Play();
            Destroy(gameObject);
        }
        else
            Instantiate(collisionParticle, transform.position, Quaternion.Euler(Vector3.zero), transform).Play();
    }
}
