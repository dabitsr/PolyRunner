using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public ParticleSystem particle;

    PlayerCounterSlider playerCounterSlider;
    PlayerScript playerScript;
    List<int> pickedAllies;

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
        if (collision.gameObject.CompareTag("FloorPlayer"))
        {
            particle.transform.position = collision.transform.position;
            particle.Play();

            // Update UI
            GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().increasePlayersCollected();

            playerCounterSlider.IncreaseSlider();

            playerScript.collectAlly();
        }
        
    }

}
