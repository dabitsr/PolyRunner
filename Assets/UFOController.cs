using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    [SerializeField] float speed, startMovingPos, abductionTime, lightTime, distanceToPlayer, lateralSpeed;
    [SerializeField] Vector2 abductRate;
    [SerializeField] Transform player;
    [SerializeField] Light spotLight;
    [SerializeField] AbductController abductController;
    bool abducting = false, abductionInvoked = false, lightOn = false;
    float initSpeed, maxLeft, maxRight;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Abduct(2));
        initSpeed = speed;

        maxLeft = GameManager.getMaxLeft();
        maxRight = GameManager.getMaxRight();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - player.position.z < distanceToPlayer)
            speed = initSpeed * 1.5f;
        else if (transform.position.z - player.position.z >= distanceToPlayer)
            speed = initSpeed / 1.5f;
        else
            speed = initSpeed;


        if (player.position.z > startMovingPos && !abducting)
        {
            if (!abductionInvoked && transform.position.z > player.position.z)
            {
                Invoke("Coroutine", Random.Range(abductRate.x, abductRate.y));
                abductionInvoked = true;
            }

            if (transform.position.x <= maxLeft || transform.position.x >= maxRight)
                lateralSpeed *= -1;

            transform.Translate(new Vector3(lateralSpeed, 0, speed) * Time.deltaTime, Space.World);
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
        abducting = lightOn = abductController.abducting = abductionInvoked = false;
    }

    void Coroutine() => StartCoroutine(Abduct());
}
