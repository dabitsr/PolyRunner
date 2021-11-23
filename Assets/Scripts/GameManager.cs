using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> bounds = new();
    public GameObject firstPlatform;

    float maxLeft, maxRight;
    GameObject player;
    Vector3 firstPlatformPos, platformSize;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
        float offset = player.GetComponent<BoxCollider>().bounds.size.x * 2;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getMaxLeft()
    {
        return maxLeft;
    }

    public float getMaxRight()
    {
        return maxRight;
    }

    public Vector3 GetFirstPlatformPos()
    {
        return firstPlatformPos;
    }

    public Vector3 GetPlatformSize()
    {
        return platformSize;
    }
}
