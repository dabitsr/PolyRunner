using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloor : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Waving");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
            /*
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Animation>().enabled = true;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            */
        }

    }
}
