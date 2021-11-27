using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] int floorPlayersNum;
    [SerializeField] GameObject floorPlayer;
    [SerializeField] float spaceBetween;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        for (int i = 0; i < floorPlayersNum; i++)
        {
            Vector3 p = new Vector3(transform.position.x, transform.position.y, transform.position.z + i * spaceBetween);
            GameObject a = Instantiate(floorPlayer, p, Quaternion.Euler(new Vector3(0, 180, 0)), transform);
            a.transform.localScale = player.transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
