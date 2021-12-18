using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaziController : MonoBehaviour
{
    [SerializeField] Transform player, gunPosition;
    [SerializeField] float distanceToWalk, distanceToShoot, speed, waitForShoot, walkDistance, bulletSpeed;
    [SerializeField] GameObject bullet;

    Animator anim;
    GameObject bulletSpawned;
    Vector3 fixedPos;
    bool walking = false, preShooting = false, triggerShoot = false, shooting = false, bulletMoving = false;
    float initX;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        initX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletMoving)
        {
            bulletSpawned.transform.position = Vector3.MoveTowards(bulletSpawned.transform.position, fixedPos, bulletSpeed * Time.deltaTime);
            //bullet.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
            //bullet.AddRelativeForce(Vector3.forward * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (preShooting)
        {
            if (!shooting)
                transform.LookAt(player);

            if (!triggerShoot)
            {
                triggerShoot = true;
            }

            if (transform.position.z - player.position.z < distanceToShoot && !shooting)
            {
                anim.SetTrigger("Shoot");
                StartCoroutine(ThrowBullet());
                fixedPos = player.position;
                shooting = true;
            }
        }

        if (walking)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - initX) > walkDistance)
            {
                walking = false;
                preShooting = true;
                anim.SetBool("isWalking", false);
            }
        }

        if (transform.position.z - player.position.z < distanceToWalk && !preShooting)
        {
            walking = true;
            anim.SetBool("isWalking", true);
        }
    }

    IEnumerator ThrowBullet()
    {
        yield return new WaitForSeconds(waitForShoot);
        bulletSpawned = Instantiate(bullet, gunPosition.position, gunPosition.rotation);
        bulletMoving = true;
    }
}
