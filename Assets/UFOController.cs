using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    [SerializeField] float speed, startMovingPos, abductionTime, lightTime, distanceToPlayer;
    [SerializeField] Transform player;
    [SerializeField] Light spotLight;
    [SerializeField] AbductController abductController;
    bool abducting = false, abductionInvoked = false, lightOn = false;
    float initSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Abduct(2));
        initSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z < distanceToPlayer)
            speed *= 1.5f;
        else if (transform.position.z - player.position.z >= distanceToPlayer)
            speed /= 1.5f;
        else
            speed = initSpeed;


        if (player.position.z > startMovingPos && !abducting)
        {
            if (!abductionInvoked)
            {
                InvokeRepeating("Coroutine", 3, 3);
                abductionInvoked = true;
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }

        if (lightOn && spotLight.intensity < 1)
        {
            spotLight.intensity = Mathf.Lerp(spotLight.intensity, 1, lightTime * Time.deltaTime);
        } else if (!lightOn && spotLight.intensity > 0)
        {
            spotLight.intensity = Mathf.Lerp(spotLight.intensity, 0, lightTime * Time.deltaTime);
        }
    }

    IEnumerator Abduct()
    {
        abducting = lightOn = abductController.abducting = true;
        yield return new WaitForSeconds(abductionTime);
        abducting = lightOn = abductController.abducting = false;
    }

    void Coroutine() => StartCoroutine(Abduct());
}
