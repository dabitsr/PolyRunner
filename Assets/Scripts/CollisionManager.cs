using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    Slider playerCounterSlider;
    PlayerScript playerScript;
    List<int> pickedAllies;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerCounterSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloorPlayer"))
        {
            // Update UI
            GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().increasePlayersCollected();

            playerCounterSlider.value += 1 / 24.0f;

            playerScript.collectAlly();
        }
        
    }

}
