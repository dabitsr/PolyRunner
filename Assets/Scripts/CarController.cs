using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed, wheelRotationSpeed;
    [SerializeField] List<GameObject> wheels;
    [SerializeField] List<AudioClip> hornAudios, engine;
    public bool stop = false;

    bool turnLeft, turnRight;
    float angle, initSpeed, initAngle;
    float turnSmoothTime, turnVelocity;
    float t = 1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        initAngle = angle = transform.rotation.y;
        initSpeed = speed;
        audioSource = GetComponent<AudioSource>();

        if (hornAudios.Count > 0)
            Invoke("PlayHornSound", Random.Range(0, 50));
    }

    void PlayHornSound()
    {
        AudioClip horn = hornAudios[Random.Range(0, hornAudios.Count)];
        audioSource.clip = horn;
        audioSource.Play();
        Invoke("PlayHornSound", Random.Range(0, 50));
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
            speed = Mathf.Lerp(speed, 0, t * Time.deltaTime);

        if (transform.rotation.x < 90 && transform.rotation.z < 90)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (!stop)
            foreach (GameObject wheel in wheels)
                wheel.transform.Rotate(Vector3.right * wheelRotationSpeed * Time.deltaTime);

        if (transform.position.y < -10)
            Destroy(gameObject);

        if (turnLeft)
        {
            angle = Mathf.SmoothDampAngle(angle, initAngle - 90, ref turnVelocity, turnSmoothTime);

            transform.Rotate(Vector3.up * angle * Time.deltaTime);
        }

        if (turnRight)
        {
            angle = Mathf.SmoothDampAngle(angle, initAngle + 90, ref turnVelocity, turnSmoothTime);
            transform.Rotate(Vector3.up * angle * Time.deltaTime);

            if (Mathf.Round(transform.eulerAngles.y % 90) == 0)
                finTurn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name != "Truck")
        {
            if (other.CompareTag("Init Turn Left")) initTurn(false, other.GetComponent<TurnCarController>().time);
            else if (other.CompareTag("Init Turn Right")) initTurn(true, other.GetComponent<TurnCarController>().time);
            else if (other.CompareTag("Fin Turn Left") || other.CompareTag("Fin Turn Right")) finTurn();
        }
        if (gameObject.name == "Truck" && other.CompareTag("StopSensor"))
        {
            stop = true;
            transform.GetChild(8).gameObject.SetActive(false);
        }
    }

    void initTurn(bool right, float time)
    {
        turnSmoothTime = time;
        turnLeft = !right;
        turnRight = right;
        speed = 6.7f;
    }

    void finTurn()
    {
        turnRight = turnLeft = false;
        speed = initSpeed;
        initAngle = transform.rotation.y;
    }
}
