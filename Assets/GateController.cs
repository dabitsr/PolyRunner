using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] float closedHieght, openedHeight, t;
    
    AudioSource audio;
    bool opening = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        transform.position = new Vector3(transform.position.x, closedHieght, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            if (transform.position.y <= openedHeight)
                transform.Translate(Vector3.up * Mathf.Lerp(transform.position.y, openedHeight, t * Time.deltaTime));
        }
    }

    public void Open()
    {
        opening = true;
        audio.Play();
    }
}
