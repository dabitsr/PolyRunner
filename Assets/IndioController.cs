using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndioController : MonoBehaviour
{
    [SerializeField] GameObject spear, attachedSpear;
    [SerializeField] float repeatRate, force;
    [SerializeField] Transform player;
    [SerializeField] bool attack;

    bool attacking = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("idle", Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (attack && player.position.z > 50)
        {
            transform.LookAt(player);
            if (!attacking)
            {
                InvokeRepeating("ThrowSpear", repeatRate / 2, repeatRate);
                attacking = true;
            }
        }
    }

    void ThrowSpear()
    {
        anim.SetTrigger("throw");
        //attachedSpear.SetActive(true);
        StartCoroutine(WaitForAnim());
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject s = Instantiate(spear, transform.position, transform.rotation, transform);
        Rigidbody rb = s.transform.GetChild(0).GetComponent<Rigidbody>();
        Vector3 v = (player.position + Vector3.up * 5) - transform.position;
        rb.AddRelativeTorque(new Vector3(Random.Range(force / 2, force * 2), Random.Range(force / 2, force * 2), Random.Range(force / 2, force * 2)));
        rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
        attachedSpear.SetActive(false);
    }
}
