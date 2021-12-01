using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] float timeToFade;
    Rigidbody rb;
    Color c;
    float a = 1;
    bool fading = false;
    int stopCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);

        if (rb.velocity.magnitude == 0)
        {
            ++stopCount;
            if (stopCount > 10)
                fading = true;
        }

        if (fading)
        {
            a = Mathf.Lerp(a, 0, timeToFade * Time.deltaTime);
            GetComponent<MeshRenderer>().material.color = new Color(c.r, c.g, c.b, a);
            if (a <= 0.03f)
                Destroy(gameObject);
        }
    }
}
