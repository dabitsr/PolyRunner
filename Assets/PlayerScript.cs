using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float frontSpeed, lateralSpeed, maxLeft, maxRight;
    public Vector3 spawnPoint;

    Animation runnningAnim;
    int playersCollected;
    int lvl;
    GameObject collectedPlayersUI;

    // Start is called before the first frame update
    void Start()
    {
        // TP al respawn
        //transform.position = Vector3.zero;
        //transform.position = new Vector3(-2.2f, 0.86f, -9);
        collectedPlayersUI = GameObject.FindGameObjectWithTag("CollectedPlayersUI");
    }

    // Update is called once per frame
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
        if (collision.gameObject.tag == "FloorPlayer")
        {
            print(collision.gameObject.name);
            playersCollected++;
            collectedPlayersUI.GetComponent<Text>().text = "Collected: " + playersCollected;
            print(playersCollected);

            // Animacion de correr
            GameObject go = collision.gameObject;
            go.GetComponent<Animator>().enabled = false;
            go.GetComponent<Animation>().enabled = true;
            go.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}

