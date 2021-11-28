using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particle, killParticle;

    PlayerCounterSlider playerCounterSlider;
    PlayerScript playerScript;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerCounterSlider = GameObject.Find("Slider").GetComponent<PlayerCounterSlider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Ally"))
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                KillAlly(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("FloorPlayer"))
            AddAlly(other.gameObject.transform.position);

        if (gameObject.CompareTag("Ally") && other.gameObject.CompareTag("People Obstacle"))
        {
            anim.SetTrigger("punch");
            KillAlly(false);
        }
    }

    void KillAlly(bool explode)
    {
        gameObject.tag = "Untagged";
        if (explode)
        {
            ParticleSystem p = Instantiate(killParticle, transform.position, transform.rotation);
            p.Play();
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Movement>().stopMoving = true;
            StartCoroutine(DestroyGameObject(gameObject));
        }
        UpdateUI(0);
    }

    IEnumerator DestroyGameObject(GameObject gameObject)
    {
        UpdateUI(-1);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void AddAlly(Vector3 pos)
    {
        Instantiate(particle, pos, transform.rotation).Play();

        playerScript.collectAlly(GameObject.FindGameObjectsWithTag("Ally").Length, null);

        UpdateUI(0);
    }

    void UpdateUI(int i)
    {
        int n = GameObject.FindGameObjectsWithTag("Ally").Length;
        playerCounterSlider.SetSlider(n + i);
        GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().SetPlayersCollected(n);
    }
}
