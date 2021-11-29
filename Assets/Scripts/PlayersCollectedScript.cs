using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersCollectedScript : MonoBehaviour
{
    float playersCollected;
    // Start is called before the first frame update
    void Start()
    {
        playersCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public float getPlayersCollected()
    {
        return playersCollected;
    }

    public void increasePlayersCollected()
    {
        playersCollected++;
        GetComponent<Text>().text = playersCollected + "/24";
    }

    public void decreasePlayersCollected()
    {
        playersCollected--;
        GetComponent<Text>().text = playersCollected + "/24";
    }

    public void SetPlayersCollected(int n)
    {
        playersCollected = n;
        GetComponent<Text>().text = playersCollected + "/24";
    }
}
