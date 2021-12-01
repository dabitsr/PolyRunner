using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed, wheelRotationSpeed = 100;
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
        /*
        if (stop)
            speed = Mathf.Lerp(speed, 0, t * Time.deltaTime);

        if (transform.rotation.x < 90 && transform.rotation.z < 90)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        */
        if (!stop)
            foreach (GameObject wheel in wheels)
                wheel.transform.Rotate(Vector3.right * wheelRotationSpeed * Time.deltaTime);

        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Truck" && other.CompareTag("StopSensor"))
        {
            stop = true;
            transform.GetChild(8).gameObject.SetActive(false);
        }
    }
}
