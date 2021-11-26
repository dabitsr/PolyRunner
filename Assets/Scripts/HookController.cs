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
        target = 360.0f - targetLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localRotation.eulerAngles.x > 90)
        {
            angle = (360.0f - transform.localRotation.eulerAngles.x) * -1;
        }

        if (angle >= targetRight + 1 && angle < 90.0f)
        {
            print("A");
            target = 360.0f - targetLeft;
        } else if (angle <= targetLeft + 1)
        {
            print("B");
            target = targetRight;
        }
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.x, target, ref hookVelocity, hookSpinTime);
        print(angle);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
