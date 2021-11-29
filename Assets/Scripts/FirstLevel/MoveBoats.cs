using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoats : MonoBehaviour
{
    public GameObject player;
    public GameObject firstBoat;
    public GameObject secondBoat;
    public GameObject thirdBoat;
    public GameObject fourthBoat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= 270) secondBoat.transform.position += new Vector3(-1.0f, 0.0f, 1.0f) * Time.deltaTime * 3;
        if (player.transform.position.z >= 300)
        {
            firstBoat.transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * 4;
            thirdBoat.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * 3;
            fourthBoat.transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * 9;
        }
    }
}
