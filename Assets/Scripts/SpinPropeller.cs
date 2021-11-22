using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spinSpeed += Random.Range(-spinSpeed / 2, spinSpeed / 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(2).Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
