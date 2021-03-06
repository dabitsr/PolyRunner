using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerController : MonoBehaviour
{
    [SerializeField] ParticleSystem flame;
    [SerializeField] float flameTime, preFlameTime;
    [SerializeField] GameObject audioSource;
    [SerializeField] AudioClip flameClip;

    int currentFlame = -1, nextFlame = 0;

    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.GetComponent<AudioSource>().maxDistance = 10;
        audioSource.GetComponent<AudioSource>().clip = flameClip;
        //StartCoroutine(NextFlame(preFlameTime));
        InvokeRepeating("StartFlame", preFlameTime, flameTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartFlame() => StartCoroutine(StartFlameCoroutine());

    IEnumerator StartFlameCoroutine()
    {
        if (currentFlame != -1)
        {
            transform.GetChild(currentFlame).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(currentFlame).GetChild(0).gameObject.GetComponent<BoxCollider>().tag = "Untagged";
            Destroy(a);
        }

        transform.GetChild(nextFlame).GetChild(1).gameObject.SetActive(false);

        currentFlame = nextFlame;
        transform.GetChild(currentFlame).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(currentFlame).GetChild(0).gameObject.GetComponent<BoxCollider>().tag = "Obstacle";
        //a = Instantiate(audioSource, transform.GetChild(currentFlame).GetChild(0).transform.position, transform.GetChild(currentFlame).GetChild(0).transform.rotation);

        StartCoroutine(NextFlame(flameTime - preFlameTime));
        yield return new WaitForSeconds(flameTime);
    }

    IEnumerator NextFlame(float s)
    {
        yield return new WaitForSeconds(s);

        int n;
        do
        {
            n = Random.Range(0, transform.childCount);
        } while (n == currentFlame);

        nextFlame = n;

        // Light
        transform.GetChild(nextFlame).GetChild(1).gameObject.SetActive(true);
    }
}
