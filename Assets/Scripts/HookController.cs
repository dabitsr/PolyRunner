using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField] float targetRight, targetLeft, hookSpinTime;

    bool goingRight = false;
    Rigidbody rb;
    float angle, target;
    float hookVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = targetLeft;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(Quaternion.Euler(Vector3.forward * 10 * Time.deltaTime));
        /*
        if (transform.eulerAngles.x > 90 && transform.eulerAngles.x < 360 - (targetLeft + 5))
        {
            target = targetRight;
        }
        else if (transform.eulerAngles.x < 90 && transform.eulerAngles.x > targetRight - 5)
            target = targetLeft;
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.x, target, ref hookVelocity, hookSpinTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + angle * Time.deltaTime, transform.eulerAngles.y, transform.eulerAngles.z);
        print(transform.eulerAngles);
         */
        //rb.MoveRotation(Quaternion.Euler(new Vector3(0, 0, angle)));
    }
}
