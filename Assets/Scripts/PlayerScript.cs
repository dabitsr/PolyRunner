using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float frontSpeed, lateralSpeed, maxLeft, maxRight;
    public Vector3 spawnPoint;
    public GameObject playerAllyPrefab;
    public PlayersCollectedScript playersCollectedScript;
    public Slider playerCounterSlider;

    Dictionary<Vector2, bool> positions;
    float distanceAllies;
    

    void Start()
    {
        transform.position = spawnPoint;
        playersCollectedScript = GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>();
        positions = new Dictionary<Vector2, bool>();
        distanceAllies = 0.15f;
    }

    void Update()
    {
        float move = 0;
        move = Input.GetAxis("Horizontal");
        if (transform.position.x >= maxRight && move > 0) move = 0;
        else if (transform.position.x <= maxLeft && move < 0) move = 0;
        transform.position = new Vector3(transform.position.x + move * lateralSpeed, transform.position.y, transform.position.z + frontSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloorPlayer"))
        {
            collectAlly();
        }
    }

    public void collectAlly()
    {
        // Update UI
        playersCollectedScript.increasePlayersCollected();
        playerCounterSlider.value = playersCollectedScript.getPlayersCollected() / 24.0f;

        // Assign position
        int n = playersCollectedScript.getPlayersCollected() - 1;
        int a = n / 4;
        Vector2 v;

        if (a == 0) v = new Vector2(distanceAllies, 0);
        else if (a == 1) v = new Vector2(distanceAllies, distanceAllies);
        else if (a == 2) v = new Vector2(distanceAllies*2, 0);
        else if (a == 3) v = new Vector2(distanceAllies*2, distanceAllies);
        else if (a == 4) v = new Vector2(distanceAllies, distanceAllies*2);
        else if (a == 5) v = new Vector2(distanceAllies*2, distanceAllies*2);
        else v = new Vector2(-1, -1);

        if (v != new Vector2(-1, -1)) v = getPos(n % 4, v);
        else print("ERROR: v == (-1, -1)");

        // Create Player Ally
        Vector3 initPos = new Vector3(transform.position.x + v.x, transform.position.y, transform.position.z + v.y);
        GameObject ally = Instantiate(playerAllyPrefab, initPos, Quaternion.Euler(new Vector3(0, 180, 0)));
        ally.GetComponent<PlayerAlly>().initValues(frontSpeed, lateralSpeed, maxLeft, maxRight, gameObject.GetComponent<PlayerScript>(), v);
    }

    Vector2 getPos(int r, Vector2 v)
    {
        if (r == 0) return setPos(v);
        if (r == 1) return setPos(v * -1);
        if (r == 2) return setPos(v * new Vector2(-1, 1));
        if (r == 3) return setPos(v * new Vector2(1, -1));
        else return Vector2.zero;
    }

    Vector2 setPos(Vector2 v)
    {
        try
        {
            bool b = positions[v];  // Ya está ocupado, cogemos el de ejes inversos
            Vector2 w = new Vector2(v.y, v.x);
            positions[w] = true;
            return w;
        }
        catch
        {
            positions[v] = true;
            return v;
        }
    }

    public void deletePos(Vector2 v)
    {
        positions[v] = false;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
}

