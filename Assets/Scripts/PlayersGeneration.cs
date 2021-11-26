using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGeneration : MonoBehaviour
{
    public GameObject playerPrefab;

    Vector3 firstPlatformPos;
    Vector3 platformSize;
    Vector3 floorSize;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {/*
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        firstPlatformPos = gameManager.GetFirstPlatformPos();
        platformSize = gameManager.GetPlatformSize();

        
        if (firstPlatformPos == Vector3.zero)
            firstPlatformPos = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        if (platformSize == Vector3.zero)
            platformSize = GetComponent<Renderer>().bounds.size;
        print(firstPlatformPos);
         
        floorSize = new Vector3(firstPlatformPos.x + platformSize.x/2, firstPlatformPos.y, firstPlatformPos.z + (platformSize.z * transform.childCount));
        print(floorSize);
        print(firstPlatformPos.z);
        for (int i = 0; i < 40; i++)
        {
            Vector3 p = new Vector3(Random.Range(gameManager.getMaxLeft(), gameManager.getMaxRight()), floorSize.y+1, Random.Range(firstPlatformPos.z, floorSize.z));
            Instantiate(playerPrefab, p, Quaternion.Euler(new Vector3(0, 180, 0)));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
