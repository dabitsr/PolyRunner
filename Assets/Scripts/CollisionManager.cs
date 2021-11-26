using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particle, killParticle;

    PlayerCounterSlider playerCounterSlider;
    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerCounterSlider = GameObject.Find("Slider").GetComponent<PlayerCounterSlider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Ally"))
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                KillAlly();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("FloorPlayer"))
            AddAlly(other.gameObject.transform.position);
    }

    void KillAlly()
    {
        ParticleSystem p = Instantiate(killParticle, transform.position, transform.rotation);
        p.Play();
        playerCounterSlider.DecreaseSlider();
        GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().decreasePlayersCollected();

        Destroy(gameObject);
    }

    void AddAlly(Vector3 pos)
    {
        Instantiate(particle, pos, transform.rotation).Play();

        // Update UI
        GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().increasePlayersCollected();

        playerCounterSlider.IncreaseSlider();

        playerScript.collectAlly(GameObject.FindGameObjectsWithTag("Ally").Length, null);
    }
}
