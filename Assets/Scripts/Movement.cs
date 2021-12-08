using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    public bool stopMoving = false;
    
    float maxLeft, maxRight;
    GameObject player;
    Vector2 posRelativeToPlayer;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody>();

        maxLeft = GameManager.getMaxLeft();
        maxRight = GameManager.getMaxRight();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Player")) movePlayer();
        else
            if (!stopMoving)
                moveAlly();
    }

    void moveAlly()
    {
        Vector3 move = Vector3.zero;
        // Offsets del jugador respecto a la posición que debería tener
        float xOffset = (transform.position.x - player.transform.position.x) - posRelativeToPlayer.x;
        float zOffset = (transform.position.z - player.transform.position.z) - posRelativeToPlayer.y;

        move.x = Input.GetAxis("Horizontal");
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

        transform.Translate(new Vector3(move.x * speed * Time.deltaTime, 0, (speed + speed * move.z) * Time.deltaTime));
    }

    void movePlayer()
    {
        float move = Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, maxLeft, maxRight);
        transform.position = new Vector3(move, transform.position.y, transform.position.z + speed * Time.deltaTime);
        /*
        if (transform.position.x >= maxRight && move > 0) move = 0;
        else if (transform.position.x <= maxLeft && move < 0) move = 0;
        transform.Translate(new Vector3(move * speed * Time.deltaTime, 0, speed * Time.deltaTime));
        */
    }

    public void setPosRelativeToPlayer(Vector2 newPos)
    {
        posRelativeToPlayer = newPos;
    }

    public Vector2 getPosRelativeToPlayer()
    {
        return posRelativeToPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            maxLeft = GameManager.getMaxLeft();
            maxRight = GameManager.getMaxRight();
        }
    }
}
