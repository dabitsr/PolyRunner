using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particle, killParticle;
    [SerializeField] AudioClip pickAudio, dieAudio;

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
        if (gameObject.CompareTag("Ally") || gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("People Obstacle"))
            {
                //KillAlly(false);
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                KillAlly(true);

                if (gameObject.CompareTag("Player"))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("FloorPlayer"))
        {
            AudioPlayerController.PlayAudio(pickAudio);
            AddAlly(other.gameObject.transform.position);
            /*
            audio.clip = pickAudio;
            audio.Play();
             */
        }

        if (gameObject.CompareTag("Ally") || other.gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("People Obstacle"))
            {
                //KillAlly(false);
            } else if (other.CompareTag("Obstacle"))
            {
                KillAlly(true);

                if (gameObject.CompareTag("Player"))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void KillAlly(bool explode)
    {
        if (explode)
        {
            AudioPlayerController.PlayAudio(dieAudio);
            ParticleSystem p = Instantiate(killParticle, transform.position, transform.rotation);
            p.Play();
            Destroy(gameObject);
            UpdateUI(-1);
        }
        else
        {
            anim.SetTrigger("punch");
            gameObject.tag = "Untagged";
            gameObject.GetComponent<Movement>().stopMoving = true;
            StartCoroutine(DestroyGameObject(gameObject));
            UpdateUI(0);
        }
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
        GameObject.Find("PlayersCounterUI").GetComponent<PlayersCollectedScript>().SetPlayersCollected(n + i);
    }
}
