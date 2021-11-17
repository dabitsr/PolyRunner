using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlly : MonoBehaviour
{
    float frontSpeed, lateralSpeed, maxLeft, maxRight;
    PlayerScript playerScript;
    Vector2 posRelativeToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;
        // Offsets del jugador respecto a la posición que debería tener
        float xOffset = (transform.position.x - playerScript.getPosition().x) - posRelativeToPlayer.x;
        float zOffset = (transform.position.z - playerScript.getPosition().z) - posRelativeToPlayer.y;

        move.x = Input.GetAxis("Horizontal");
        print(zOffset);
        if (transform.position.x >= maxRight)
        {
            transform.position = new Vector3(maxRight, transform.position.y, transform.position.z);
            if (xOffset > 0) move.x += (xOffset * -1);
            if (move.x > 0) move.x = 0;
        }
        else if (transform.position.x <= maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
            if (xOffset < 0) move.x += (xOffset * -1);
            if (move.x < 0) move.x = 0;
        }
        else if (xOffset != 0 || zOffset != 0)
        {
            move.x += (xOffset * -1);
            move.z += (zOffset * -1);
        }
        transform.position = new Vector3(transform.position.x + move.x * lateralSpeed, transform.position.y, transform.position.z + frontSpeed + move.z * frontSpeed);
    }

    public void initValues(float frontSpeed, float lateralSpeed, float maxLeft, float maxRight, PlayerScript playerScript, Vector2 posRelativeToPlayer)
    {
        this.frontSpeed = frontSpeed;
        this.lateralSpeed = lateralSpeed;
        this.maxLeft = maxLeft;
        this.maxRight = maxRight;
        this.playerScript = playerScript;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        this.posRelativeToPlayer = posRelativeToPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("FloorPlayer"))
        {
            playerScript.collectAlly();
        }
    }
    public void updateRelativePos(Vector2 newPos)
    {
        this.posRelativeToPlayer = newPos;
    }
}