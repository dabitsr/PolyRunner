using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        followPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 2.52f, player.position.z - 5.3f);
        transform.rotation = Quaternion.Euler(player.rotation.x + 15, player.rotation.y, 0);
    }
}
