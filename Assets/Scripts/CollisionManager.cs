using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public ParticleSystem particle, killParticle;

    PlayerCounterSlider playerCounterSlider;
    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerCounterSlider = GameObject.Find("Slider").GetComponent<PlayerCounterSlider>();
        killParticle = GameObject.Find("Kill Particle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Ally") && other.CompareTag("Obstacle"))
        {
            killParticle.transform.position = transform.position;
            killParticle.Play();
            Destroy(gameObject);
            playerCounterSlider.DecreaseSlider();
            GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().decreasePlayersCollected();
        }

        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("FloorPlayer"))
            AddAlly(other.gameObject.transform.position);
    }

    void AddAlly(Vector3 pos)
    {
        particle.transform.position = pos;
        particle.Play();

        // Update UI
        GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().increasePlayersCollected();

        playerCounterSlider.IncreaseSlider();

        playerScript.collectAlly(GameObject.FindGameObjectsWithTag("Ally").Length, null);
    }
}
