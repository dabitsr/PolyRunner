using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> bounds = new();
    public GameObject firstPlatform, floor, floorPlayerPrefab;
    public int floorPlayersCount;

    float maxLeft, maxRight;
    GameObject player;
    Vector3 firstPlatformPos, platformSize;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        player = GameObject.Find("Player");
        
        float offset = player.GetComponent<BoxCollider>().bounds.size.x;
        if (bounds.Count > 1)
        {
            maxLeft = bounds[0].gameObject.transform.position.x + offset;
            maxRight = bounds[1].gameObject.transform.position.x - offset;
        }
        else
        {
            print(bounds[0].transform.position);
            print(bounds[0].GetComponent<BoxCollider>().bounds.size);
        }

        firstPlatformPos = firstPlatform.transform.position;
        platformSize = firstPlatform.GetComponent<BoxCollider>().bounds.size - Vector3.right*offset*2;

        //GenerateFloorPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateFloorPlayers()
    {
        Vector3 floorSize = new Vector3(firstPlatformPos.x + platformSize.x / 2, firstPlatformPos.y, firstPlatformPos.z + (platformSize.z * floor.transform.childCount));
        for (int i = 0; i < floorPlayersCount; i++)
        {
            Vector3 p = new Vector3(Random.Range(maxLeft, maxRight), floorSize.y + 1, Random.Range(firstPlatformPos.z, floorSize.z));
            GameObject a = Instantiate(floorPlayerPrefab, p, Quaternion.Euler(new Vector3(0, 180, 0)));
            a.transform.localScale = player.transform.localScale;
        }
    }

    public float getMaxLeft()
    {
        return maxLeft;
    }

    public float getMaxRight()
    {
        return maxRight;
    }
}
