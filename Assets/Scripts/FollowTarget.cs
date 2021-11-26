using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public bool scene;
    public float offset;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        followPlayer();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        followPlayer();
    }

    void followPlayer()
    {
        // Temporal script
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, player.transform.position.z - offset);
        transform.rotation = Quaternion.Euler(Vector3.right * 30);
        /*
        if (scene)
        {
            if (player.position.z <= 48.5f)
            {
                transform.position = new Vector3(2.65f, player.position.y + 2.0f, player.position.z - 2.8f);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.position.y + 2.0f, player.position.z - 2.8f), 4 * Time.deltaTime);
            }
            transform.rotation = Quaternion.Euler(player.rotation.x + 15, player.rotation.y, 0);
        } else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 2.0f, player.position.z - 3.8f);
            transform.rotation = Quaternion.Euler(player.rotation.x + 15, player.rotation.y, 0);
        }
         */
    }
}
