using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGeneration : MonoBehaviour
{
    public Vector3 firstPlatformPos;
    public GameObject playerPrefab;

    Vector3 floorSize;
    Vector3 platformSize;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        firstPlatformPos = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        print(firstPlatformPos);
        platformSize = GetComponent<Renderer>().bounds.size;
        floorSize = new Vector3(firstPlatformPos.x + platformSize.x/2, firstPlatformPos.y, firstPlatformPos.z + (platformSize.z * transform.childCount));
        print(floorSize);

        for (int i = 0; i < 5; i++)
        {
            Vector3 p = new Vector3(Random.Range(firstPlatformPos.x, floorSize.x), floorSize.y, Random.Range(firstPlatformPos.z, floorSize.z));
            Instantiate(playerPrefab, p, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            print("AAA");
            anim.Play("Running");
        }
    }
}
