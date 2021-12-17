using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    [SerializeField] float blinkRate, diffSpeed, lightTime, distance, explodeTime;
    [SerializeField] Light light;
    [SerializeField] Transform player;
    [SerializeField] ParticleSystem explosion;

    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z < distance && !started)
        {
            Blink();
            started = true;
        }
    }

    void Blink()
    {
        if (blinkRate > 0.001f)
            StartCoroutine(BlinkEnum());
        else
        {
            light.gameObject.SetActive(true);
            StartCoroutine(Explode());
            gameObject.tag = "Obstacle";
        }
    }

    IEnumerator BlinkEnum()
    {
        light.gameObject.SetActive(true);
        yield return new WaitForSeconds(lightTime * Time.deltaTime);
        light.gameObject.SetActive(false);
        blinkRate /= diffSpeed;
        lightTime /= diffSpeed;
        Invoke("Blink", blinkRate);
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(explodeTime * Time.deltaTime);
        explosion.Play();
    }
}
